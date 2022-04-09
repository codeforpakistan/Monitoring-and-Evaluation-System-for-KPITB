using Dapper;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Dapper.SqlMapper;

namespace Repositories
{
    public static class Repose
    {
        public static StatusModel ExcuteNonQueryWithStatusModel(string StoreProcedure, DynamicParameters ObjParm, string ValueInside, ref int ValueOutside)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(DbConnection.ConnectionString);
                Con.Open();

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                ObjParm.Add(ValueInside, dbType: DbType.Int32, direction: ParameterDirection.Output);
                Con.Execute(StoreProcedure, ObjParm, commandType: CommandType.StoredProcedure);

                ValueOutside = Convert.ToInt32(ObjParm.Get<Int32>(ValueInside));
                status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
            }
            catch (Exception ex)
            {
                status.status = false;
                status.statusDetail = ex.Message;
            }
            finally
            {
                Con.Close();
            }
            return status;
        }

        public static StatusModel ExcuteNonQueryWithStatusModel(string StoreProcedure, DynamicParameters ObjParm)
        {
            StatusModel status = new StatusModel();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(DbConnection.ConnectionString);
                Con.Open();

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                Con.Execute(StoreProcedure, ObjParm, commandType: CommandType.StoredProcedure);

                status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
                status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
            }
            catch (Exception ex)
            {
                status.status = false;
                status.statusDetail = ex.Message;
            }
            finally
            {
                Con.Close();
            }
            return status;
        }

        public static int ExcuteNonQuery(string StoreProcedure, List<DynamicParameters> parmList)
        {
            int isInserted = 0;
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(DbConnection.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                if (parmList != null)
                {
                    foreach (DynamicParameters parm in parmList)
                    {
                        //ObjParm.Add("@ProjectID", parm);
                        ObjParm.AddDynamicParams(parm);
                    }
                }

                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
                isInserted = Con.Execute(StoreProcedure, ObjParm, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
            }
            return isInserted;
        }


        public static List<T> GetList<T>(string StoreProcedure, DynamicParameters parmList)
        {

            List<T> list = new List<T>();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(DbConnection.ConnectionString);
                Con.Open();
               
                list = Con.Query<T>(StoreProcedure, parmList, commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
                Con.Dispose();
            }
        }


        public static List<T> GetList<T>(string StoreProcedure, List<DynamicParameters> parmList)
        {

            List<T> list= new List<T>();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(DbConnection.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                if (parmList != null)
                {
                    foreach (DynamicParameters parm in parmList)
                    {
                        //ObjParm.Add("@ProjectID", parm);
                        ObjParm.AddDynamicParams(parm);
                    }
                }
                list = Con.Query<T>(StoreProcedure, ObjParm, commandType: CommandType.StoredProcedure).ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
                Con.Dispose();
            }
        }

        public static List<T> GetMultiList <T>(string StoreProcedure, List<DynamicParameters> parmList)//, params T[] additions
        {
             
            List<T> list = new List<T>(); //Single
            List<T> Multilist = new List<T>(); //Single
           
            var ss = new List<T>();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(DbConnection.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                if (parmList != null)
                {
                    foreach (DynamicParameters parm in parmList)
                    {
                        //ObjParm.Add("@ProjectID", parm);
                        ObjParm.AddDynamicParams(parm);
                    }
                }
                SqlMapper.GridReader multi = Con.QueryMultiple(StoreProcedure, ObjParm, commandType: CommandType.StoredProcedure);
                int count = 0;
                while (!multi.IsConsumed)
                {
                    ss =multi.Read<T>().ToList();
                    list.AddRange(ss);
                    list.InsertRange(count, ss);
                    count++;
                    Multilist.InsertRange(list.Count, list);
                }
                Multilist.AddRange(list);
                multi.Dispose();

                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
                Con.Dispose();
            }
        }



        #region MULTI
        public static List<object> getMultiple(string sql, object parameters1, params Func<GridReader, object>[] readerFuncs)
        {
            var returnResults = new List<object>();
            using (IDbConnection db = new SqlConnection(DbConnection.ConnectionString))
            {



                GridReader gridReader = db.QueryMultiple(new CommandDefinition(sql, commandType: System.Data.CommandType.StoredProcedure, parameters: parameters1));
             
                    //gridReader = db.QueryMultiple(sql, parameters);
                



                foreach (var readerFunc in readerFuncs)
                {
                    var obj = readerFunc(gridReader);
                    returnResults.Add(obj);
                }
            }
            return returnResults;
        }
        public static Tuple<IEnumerable<T1>, IEnumerable<T2>> GetMultiple<T1, T2>(string sql, object parameters,
                                         Func<GridReader, IEnumerable<T1>> func1,
                                         Func<GridReader, IEnumerable<T2>> func2)
        {
            var objs = getMultiple(sql, parameters, func1, func2);
            return Tuple.Create(objs[0] as IEnumerable<T1>, objs[1] as IEnumerable<T2>);
        }

        public static Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> GetMultiple<T1, T2, T3>(string sql, DynamicParameters parameters,
                                        Func<GridReader, IEnumerable<T1>> func1,
                                        Func<GridReader, IEnumerable<T2>> func2,
                                        Func<GridReader, IEnumerable<T3>> func3)
        {
            var objs = getMultiple(sql, parameters, func1, func2, func3);
            return Tuple.Create(objs[0] as IEnumerable<T1>, objs[1] as IEnumerable<T2>, objs[2] as IEnumerable<T3>);
        }


        #endregion


        public static void AddMany<T>(this List<T> list, params T[] elements)
        {
            list.AddRange(elements);
        }




        public static object GetSingleModel(string StoreProcedure, List<DynamicParameters> parmList)
        {
            object model = new object();
            IDbConnection Con = null;
            try
            {
                Con = new SqlConnection(DbConnection.ConnectionString);
                Con.Open();
                DynamicParameters ObjParm = new DynamicParameters();
                if (parmList != null)
                {
                    foreach (DynamicParameters parm in parmList)
                    {
                        //ObjParm.Add("@ProjectID", parm);
                        ObjParm.AddDynamicParams(parm);
                    }
                }
                model = Con.Query<object>(StoreProcedure, ObjParm, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Con.Close();
                Con.Dispose();
            }
        }



       

        //public static object ExcuteNonQueryWithStatusModel(List<string, DynamicParameters> StoreProcedureList, List<> parmList)
        //{
        //    StatusModel status = new StatusModel();
        //    IDbConnection Con = null;
        //    try
        //    {
        //        using (TransactionScope transactionScope = new TransactionScope())
        //        {
        //            foreach (var StoreProcedure in StoreProcedureList)
        //            {
        //                Con = new SqlConnection(Common.ConnectionString);
        //                Con.Open();
        //                DynamicParameters ObjParm = new DynamicParameters();
        //                if (parmList != null)
        //                {
        //                    foreach (DynamicParameters parm in parmList)
        //                    {
        //                        //ObjParm.Add("@ProjectID", parm);
        //                        ObjParm.AddDynamicParams(parm);
        //                    }
        //                }

        //                ObjParm.Add("@Status", dbType: DbType.Boolean, direction: ParameterDirection.Output);
        //                ObjParm.Add("@StatusDetails", dbType: DbType.String, direction: ParameterDirection.Output, size: 4000);
        //                Con.Execute(StoreProcedure, ObjParm, commandType: CommandType.StoredProcedure);
        //                Con.Close();
        //                status.status = Convert.ToBoolean(ObjParm.Get<bool>("@Status"));
        //                status.statusDetail = Convert.ToString(ObjParm.Get<string>("@StatusDetails"));
        //            }
        //            transactionScope.Complete();
        //            transactionScope.Dispose();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status.status = false;
        //        status.statusDetail = ex.Message;
        //    }
        //    finally
        //    {
        //    }
        //    return status;
        //}

    }
}
