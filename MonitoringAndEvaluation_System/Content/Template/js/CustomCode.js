//ALL
$(document).ready(function () {
    $("#RecruitedHR").val('');
    $("#NoOfProcurement").val('');
    $("#ReleasedBudget").val('');
    $("#ExpenditureBudget").val('');
    $("#SubProject_ID").prop("disabled", true);
    $("#Batch_ID").prop("disabled", true);
    $("#InsightIndicator_ID").prop("disabled", true);
});

//HR
$("#RecruitedFromHRDate").on('change', function () {
    debugger
    RecruitedDateCompare();
});
$("#RecruitedToHRDate").on('change', function () {
    debugger
    RecruitedDateCompare();
});
function RecruitedDateCompare() {
    var _RecruitedToHRDate = $('#RecruitedToHRDate').val();

    var _RecruitedFromHRDate = $('#RecruitedFromHRDate').val();
    if (_RecruitedToHRDate != '') {
        if (_RecruitedFromHRDate > _RecruitedToHRDate) {
            $("#spanRecruitedFromHRDate").text("From-HRDate should not be greater then  To-HRDate");
            return false;
        }
        else {
            $("#spanRecruitedFromHRDate").text("");
            return false;
        }
    }
}
$("#RecruitedHR").on('change', function () {
    CheckHRRemaningValue();
});
function CheckHRRemaningValue() {
    debugger;
    var _RecruitedHR = $("#RecruitedHR").val();
    var _RemaningRecruitedHR = $("#lblRemaningHR").text();
    if (parseInt(_RecruitedHR) > parseInt(_RemaningRecruitedHR)) {
        $("#spanRecruitedHR").text("RecruitedHR should not be greater than Planned-HR");
        $("#spanRecruitedHR").show();
        $("#RecruitedHR").focus();
        return false;
    } else {
        $("#spanRecruitedHR").text("");
        $("#spanRecruitedHR").hide();
        return false;
    }
}
//Procurement
$("#PlannedProcrumentNo").on('change', function () {
    CheckProcurementRemaningValue();
});
function CheckProcurementRemaningValue() {
    debugger;
    var _Procurement = $("#PlannedProcrumentNo").val();
    var _RemaningProcurement = $("#lblRemainingProcurement").text();
    if (parseInt(_Procurement) > parseInt(_RemaningProcurement)) {
        $("#spanProcurementHead").text("Procurement should not be greater than AchivedProcurement");
        $("#spanProcurementHead").show();
        $("#ProcurementHead").focus();
        return true;
    } else {
        $("#spanProcurementHead").text("");
        $("#spanProcurementHead").hide();
        return true;
    }
}
$("#ProcurementToDate").on('change', function () {
    debugger
    ProcurementDateCompare();
});
function ProcurementDateCompare() {
    var _ProcurementFromHRDate = $('#ProcurementFromDate').val();
    var _ProcurementToHRDate = $('#ProcurementToDate').val();

    if (_ProcurementToHRDate != '') {
        if (_ProcurementFromHRDate > _ProcurementToHRDate) {

            $("#spanProcurementFromDate").text("To-Date should not be greater then From-Date")
            return false;
        }
        else {
            $("#spanProcurementFromDate").text("")
            return false;
        }
    }
}
//ReleasedBudget
$("#ReleasedDate").on('change', function () {
    debugger
    ReleasedDateCompare();
});
//$("#ReleasedDate").on('change', function () {
//    debugger
//    ReleasedDateCompare();
//});
function ReleasedDateCompare() {
    var _ReleasedFromDate = $('#ReleasedFromDate').val();
    var _ReleasedToDate = $('#ReleasedToDate').val();

    if (_ReleasedToDate != '') {
        if (_ReleasedFromDate > _ReleasedToDate) {

            $("#spanReleasedFromDate").text("From-Date should not be greater then  To-Date")
            return false;
        }
        else {
            $("#spanReleasedFromDate").text("")
            return false;
        }
    }
}
$("#ReleasedBudget").on('change', function () {
    CheckReleasedRemaningValue();
});
function CheckReleasedRemaningValue() {
    debugger;
    var _RecruitedHR = $("#ReleasedBudget").val();
    var _RemaningRecruitedHR = $("#lblRemaningBudget").text();
    if (parseInt(_RecruitedHR) > parseInt(_RemaningRecruitedHR)) {
        $("#spanReleasedBudget").text("ReleasedBudget should not be greater than Approved");
        $("#spanReleasedBudget").show();
        $("#ReleasedBudget").focus();
        return true;
    } else {
        $("#spanReleasedBudget").text("");
        $("#spanReleasedBudget").hide();
        return true;
    }
}

//ReleasedBudget
$("#spanExpenditureFromDate").on('change', function () {
    debugger
    ExpenditureDateCompare();
});
$("#spanExpenditureToDate").on('change', function () {
    debugger
    ExpenditureDateCompare();
});
function ExpenditureDateCompare() {
    var _RecruitedToHRDate = $('#RecruitedToHRDate').val();

    var _RecruitedFromHRDate = $('#RecruitedFromHRDate').val();
    if (_RecruitedToHRDate != '') {
        if (_RecruitedFromHRDate > _RecruitedToHRDate) {
            $("#spanRecruitedFromHRDate").text("From-HRDate should not be greater then  To-HRDate")
            return false;
        }
        else {
            $("#spanRecruitedFromHRDate").text("")
            return false;
        }
    }
}
$("#ExpenditureBudget").on('change', function () {
    CheckReleasedRemaningValue();
});
function CheckReleasedRemaningValue() {
    debugger;
    var _ExpenditureBudget = $("#ExpenditureBudget").val();
    var _RemaningExpenditureBudget = $("#lblExpenditureBudget").text();
    if (parseInt(_ExpenditureBudget) > parseInt(_RemaningExpenditureBudget)) {
        $("#spanExpenditureBudget").text("ExpenditureBudget should not be greater than Approval");
        $("#spanExpenditureBudget").show();
        $("#ExpenditureBudget").focus();
        return true;
    } else {
        $("#spanExpenditureBudget").text("");
        $("#spanExpenditureBudget").hide();
        return true;
    }
}

//Issue
$("#IssueFromHRDate").on('change', function () {
    debugger
    IssueDateCompare();
});
$("#IssueToHRDate").on('change', function () {
    debugger
    IssueDateCompare();
});
function IssueDateCompare() {
    var _RecruitedToHRDate = $('#RecruitedToHRDate').val();

    var _RecruitedFromHRDate = $('#RecruitedFromHRDate').val();
    if (_RecruitedToHRDate != '') {
        if (_RecruitedFromHRDate > _RecruitedToHRDate) {
            $("#spanRecruitedFromHRDate").text("From-HRDate should not be greater then  To-HRDate")
            return false;
        }
        else {
            $("#spanRecruitedFromHRDate").text("")
            return false;
        }
    }
}

$("#InsightIndicator_ID").on('change', function () {
    var Url_Value = $('#InsightIndicatorComboLink').attr('url-Val');
    var obj = {};
    obj.InsightIndicatorID = $("#InsightIndicator_ID").find("option:selected").val();

    debugger;
    $.ajax({
        type: 'POST',
        url: Url_Value,
        data: JSON.stringify(obj),  // Same Parameter with Action
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (IndicatorTypeLst) {
            $("#tblBodyInsightIndicator").empty();
            $("#tblBodyInsightIndicator2").empty();
            debugger;

            var counter = 1;
            var loop = 0;
            $.each(IndicatorTypeLst.dataTypeVMLst, function (index, v)
            {
                /// do stuff

                debugger;
                var InsightIndicatorFieldID = '<td style="display:none";><input  name="dataTypeVMLst[' + loop + '].InsightIndicatorFieldID" value="' + v.InsightIndicatorFieldID + '" type="text"  /></td>';
                var HiddenValue = '';
                var ResultString = '';

                ResultString = '<td>';

                HiddenValue = ' <td>';

                if (v.InsightIndicatorDataType_ID == 1) {
                    ResultString += '<input  class="form-control"    name="dataTypeVMLst[' + loop + '].TEXT"     type="text"  placeholder="Enter Indicator Text" required />'
                    HiddenValue += '<input class="form-control"   name="dataTypeVMLst[' + loop + '].IndicatorDataType_ID" value="' + v.InsightIndicatorDataType_ID + '" type="text"   style="display:none;" />'
                } else if (v.InsightIndicatorDataType_ID == 2) {
                    ResultString += '<input class="form-control"    name="dataTypeVMLst[' + loop + '].INTEGER" type="number"  placeholder="Enter Indicator Value" required />'
                    HiddenValue += '<input class="form-control"   name="dataTypeVMLst[' + loop + '].IndicatorDataType_ID" value="' + v.InsightIndicatorDataType_ID + '" type="text"   style="display:none;" />'
                } else if (v.InsightIndicatorDataType_ID == 3) {
                    ResultString += '<input class="form-control"  name="dataTypeVMLst[' + loop + '].FLOAT" type="number" placeholder="Enter Indicator Percentage %"  required />'
                    HiddenValue += '<input class="form-control"  name="dataTypeVMLst[' + loop + '].IndicatorDataType_ID"  value="' + v.InsightIndicatorDataType_ID + '" type="text"   style="display:none;" />'
                } else if (v.InsightIndicatorDataType_ID == 4) {
                    ResultString += '<select class="form-control" name="dataTypeVMLst[' + loop + '].BOOL" required >'
                    ResultString += '<option value="">Select Yes/No</option>'
                    ResultString += '<option value="true">Yes</option>'
                    ResultString += '<option value="false">No</option>'
                    ResultString += '</select>'
                    HiddenValue += '<input class="form-control"  name="dataTypeVMLst[' + loop + '].IndicatorDataType_ID"  value="' + v.InsightIndicatorDataType_ID + '" type="text"   style="display:none;" />'
                }

                ResultString += '</td> ';
                HiddenValue += '</td>';

                $('<tr id="tblIndicatorRow' + loop + '">' +
                    '<td>' + counter + '</td>' +
                    InsightIndicatorFieldID +
                    '<td>' + v.InsightIndicatorFieldName + '</td>' +
                    ResultString +
                    HiddenValue +
                    '</tr>').appendTo('#tblInsightIndicator');
                counter++;
                loop++;
            });
            debugger;
            var counter2 = 1;
            $.each(IndicatorTypeLst.dataTypeCommonVMLst, function (index, v) {

                $('<tr><td>' + counter2 + '</td><td>' + v.InsightIndicatorFieldName + '</td><td>' + v.CommonValue + '</td><tr>').appendTo('#tbInsightlIndicator2');
                counter2++;
            });


        },
        error: function (ex) {
            debugger;
            console.log('Failed to Retrieve IndicatorDataTypeCommonValue List Data:  ' + ex.responseText);
        }
    });//Ajax_End
});


$("#SubProject_ID").on('change', function () {
    debugger;
    var Url_SubProject = $('#ProjectComboLink').attr('url-Val');
    var obj = {};
    obj.ProjectID = $("#Project_ID").find("option:selected").val();
    obj.SubProjectID = $("#SubProject_ID").find("option:selected").val();

    //var Stock = { Project_ID: $("#Project_ID").find("option:selected").val(), Batch_ID: $("#Batch_ID").find("option:selected").val() };
    $.ajax({
        type: 'POST',
        url: Url_SubProject,
        data: JSON.stringify(obj),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',

        success: function (response) {
            $("#Batch_ID").empty();
            $("#InsightIndicator_ID").empty();
            //ComboBatch
            if (response.comboBatches.length <= 1) {
                $("#Batch_ID").prop("disabled", true);
                $("#Batch_ID").append('<option value="' + 0 + '">' +
                    "Please Select Batch" + '</option>');

                $("#InsightIndicator_ID").prop("disabled", true);
                $("#InsightIndicator_ID").append('<option value="' + 0 + '">' +
                    "Please Select InsightIndicator" + '</option>');
                $("#tblBodyInsightIndicator").empty();

            } else {
                $("#Batch_ID").prop("disabled", false);
                $.each(response.comboBatches, function (i, item) {
                    $("#Batch_ID").append('<option value="' + item.BatchID + '">' +
                        item.BatchName + '</option>');
                });

                //Indicators
                $.each(response.comboIndicators, function (i, Aqib2) {
                    $("#InsightIndicator_ID").prop("disabled", false);
                    $("#InsightIndicator_ID").append('<option value="' + Aqib2.InsightIndicatorID + '">' +
                        Aqib2.InsightIndicatorName + '</option>');
                });
            }

            //RemainingVaues
            $("#RecruitedHR").val('');
            $("#PlannedProcrumentNo").val('');
            $("#ReleasedBudget").val('');
            $("#ApprovedBudget").val('');
            $("#ReleasedBudget").val('');

            $("#lblRemaningHR").text(response.remainingValues.RemainingPlannedHR);
            $("#hdnRemaningHR").val(response.remainingValues.RemainingPlannedHR);//Hidden

            $("#lblRemainingProcurement").text(response.remainingValues.RemainingProcurement);
            $("#hdnRemainingProcurement").val(response.remainingValues.RemainingProcurement); //Hidden

            $("#lblRemaningBudget").text(response.remainingValues.RemainingBudget);
            $("#hdnRemaningBudget").val(response.remainingValues.RemainingBudget); //Hidden

            $("#lblExpenditureBudget").text(response.remainingValues.ApprovedBudget);
            $("#hdnExpenditureBudget").val(response.remainingValues.ApprovedBudget); //Hidden

            $("#lblTotalReleasedBudget").text(response.remainingValues.ReleasedBudget);
            $("#hdnTotalReleasedBudget").val(response.remainingValues.ReleasedBudget); //Hidden
        }
    });//Ajax_End
});
 
$("#Project_ID").on('change', function () {
    debugger;
   
    var Url_Value = $('#ProjectComboLink').attr('url-Val');

    var obj = {};
    obj.ProjectID = $("#Project_ID").find("option:selected").val();
    obj.SubProjectID = $("#SubProject_ID").find("option:selected").val();
    obj.Batch_ID = $("#SubProject_ID").find("option:selected").val();
    var _IsEvaluationForm = $('#IsEvaluationForm').val();
    var _IsChangeManagementForm = $('#IsChangeManagementForm').val();
     
    if (_IsEvaluationForm == undefined) {
        obj._IsEvaluationForm = null;
    } else {
        obj._IsEvaluationForm = _IsEvaluationForm;
    }
    if (_IsChangeManagementForm == undefined) {
        obj._IsChangeManagementForm = null;
    } else {
        obj._IsChangeManagementForm = _IsChangeManagementForm;
    }

   

    $.ajax({
        type: 'POST',
        url: Url_Value,
        dataType: 'json',
        /*data: JSON.stringify(obj),*/
        data: obj,
        success: function (response) {
            debugger;
            $("#Batch_ID").empty();
            $("#SubProject_ID").empty();
            $("#InsightIndicator_ID").empty();

            debugger;
            //ComboSubProject
            if (response.comboSubProjects.length <= 1) {
                $("#SubProject_ID").prop("disabled", true);
                $("#SubProject_ID").append('<option value="' + 0 + '">' +
                    "Please Select SubProject" + '</option>');
            } else {
                $("#SubProject_ID").prop("disabled", false);
                $.each(response.comboSubProjects, function (i, item) {
                    $("#SubProject_ID").append('<option value="' + item.SubProjectID + '">' +
                        item.SubProjectName + '</option>');
                });
            }

            //ComboBatch
            if (response.comboBatches.length <= 1) {
                $("#Batch_ID").prop("disabled", true);
                $("#Batch_ID").append('<option value="' + 0 + '">' +
                    "Please Select Batch" + '</option>');

                $("#InsightIndicator_ID").prop("disabled", true);
                $("#InsightIndicator_ID").append('<option value="' + 0 + '">' +
                    "Please Select InsightIndicator" + '</option>');

                $("#tblBodyInsightIndicator").empty();

            } else {
                $("#Batch_ID").prop("disabled", false);
                $.each(response.comboBatches, function (i, item) {
                    $("#Batch_ID").append('<option value="' + item.BatchID + '">' +
                        item.BatchName + '</option>');
                });

                //Indicators
                $.each(response.comboIndicators, function (i, Aqib2) {
                    $("#InsightIndicator_ID").prop("disabled", false);
                    $("#InsightIndicator_ID").append('<option value="' + Aqib2.InsightIndicatorID + '">' +
                        Aqib2.InsightIndicatorName + '</option>');
                });
            }



            //RemainingVaues
            $("#RecruitedHR").val('');
            $("#PlannedProcrumentNo").val('');
            $("#ReleasedBudget").val('');
            $("#ApprovedBudget").val('');
            $("#ReleasedBudget").val('');

            $("#lblRemaningHR").text(response.remainingValues.RemainingPlannedHR);
            $("#hdnRemaningHR").val(response.remainingValues.RemainingPlannedHR);//Hidden

            $("#lblRemainingProcurement").text(response.remainingValues.RemainingProcurement);
            $("#hdnRemainingProcurement").val(response.remainingValues.RemainingProcurement); //Hidden

            $("#lblRemaningBudget").text(response.remainingValues.RemainingBudget);
            $("#hdnRemaningBudget").val(response.remainingValues.RemainingBudget); //Hidden

            $("#lblExpenditureBudget").text(response.remainingValues.ApprovedBudget);
            $("#hdnExpenditureBudget").val(response.remainingValues.ApprovedBudget); //Hidden

            $("#lblTotalReleasedBudget").text(response.remainingValues.ReleasedBudget);
            $("#hdnTotalReleasedBudget").val(response.remainingValues.ReleasedBudget); //Hidden
              
            //EvaulationList      batchIndicatorVM.InsightIndicatorForEvaulationList
            if (response.IsEvaluationForm == "Evaluation") {

                $("#tblBodyKPIs").empty();
                $("#tblBodyInsightIndicator").empty();

                var counter = 1;
                var loop = 0;
                //KPIS
                $.each(response.ListOfInsightIndicatorAndKPIs.ListKPIs, function (index, v) {
                    /// do stuff

                    debugger;
                    var PlannedKPIsID = '<td style="display:none";><input  name="ListOfInsightIndicatorAndKPIs.ListKPIs[' + loop + '].PlannedKPIsID"  value="' + v.PlannedKPIsID + '" type="text"  /></td>';  //Hidden
                    var ProjectKPIsStatusID = '<td style="display:none";><input  name="ListOfInsightIndicatorAndKPIs.ListKPIs[' + loop + '].ProjectKPIsStatusID"  value="' + v.ProjectKPIsStatusID + '" type="text"  /></td>';  //Hidden

                    var IndicatorDescription = '';
                    IndicatorDescription = '<td>';
                    IndicatorDescription += '<input  class="form-control "    readonly name="ListOfInsightIndicatorAndKPIs.ListKPIs[' + loop + '].IndicatorDescription"    value="' + v.IndicatorDescription + '"      type="text"  placeholder="Enter Indicator Description" required />'
                    IndicatorDescription += '</td> ';


                    var ProjectKPIsAchived = '';
                    ProjectKPIsAchived = '<td>';
                    ProjectKPIsAchived += '<input class="form-control "    readonly name="ListOfInsightIndicatorAndKPIs.ListKPIs[' + loop + '].ProjectKPIsAchived"  value="' + v.ProjectKPIsAchived + '"  type="number"  placeholder="Enter ProjectKPIsAchived Value" required />'
                    ProjectKPIsAchived += '</td> ';

                    var Feedback = '';
                    Feedback = '<td>';
                    Feedback += '<select class="form-control" name="ListOfInsightIndicatorAndKPIs.ListKPIs[' + loop + '].Feedback" required >'
                    Feedback += '<option value="">Select Option</option>'
                    Feedback += '<option value="true">Satisfied</option>'
                    Feedback += '<option value="false">Non-Satisfied</option>'
                    Feedback += '</select>'
                    Feedback += '</td> ';




                    var Remarks = '';
                    Remarks = '<td>';
                    Remarks += '<input class="form-control"    name="ListOfInsightIndicatorAndKPIs.ListKPIs[' + loop + '].Remarks"   type="text"  placeholder="Enter Remarks" required />'
                    Remarks += '</td> ';

                    //TABLE INSERTION
                    $('<tr id="tblKPIsRow' + loop + '">' +
                        '<td>' + counter + '</td>' +
                        PlannedKPIsID +
                        ProjectKPIsStatusID +
                        IndicatorDescription +
                        ProjectKPIsAchived +
                        Feedback +
                        Remarks +
                        '</tr>').appendTo('#tblKPIs');
                    counter++;
                    loop++;
                });
                 
                debugger;

                //InsightIndicator
                $.each(response.ListOfInsightIndicatorAndKPIs.ListInsightIndicator, function (index, v) { 
                    var InsightIndicatorFieldID = '<td style="display:none";><input  name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].InsightIndicatorFieldID" value="' + v.InsightIndicatorFieldID + '" type="text"  /></td>';
                    var HiddenValue = '';
                    var ResultString = '';

                    ResultString = '<td>'; 
                    HiddenValue = ' <td>';

                    if (v.InsightIndicatorDataType_ID == 1) {
                        ResultString += '<input  class="form-control"   readonly  name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].TEXT"     type="text"    value="' + v.TEXT + '"  placeholder="Enter Indicator Text" required />'
                        HiddenValue += '<input   readonly   name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].IndicatorDataType_ID" value="' + v.InsightIndicatorDataType_ID + '" type="text"   style="display:none;" />'
                    } else if (v.InsightIndicatorDataType_ID == 2) {
                        ResultString += '<input class="form-control"     readonly   name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].INTEGER" type="number"  value="' + v.INTEGER + '"  placeholder="Enter Indicator Value" required />'
                        HiddenValue += '<input class="form-control"   readonly  name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].IndicatorDataType_ID" value="' + v.InsightIndicatorDataType_ID + '" type="text"   style="display:none;" />'
                    } else if (v.InsightIndicatorDataType_ID == 3) {
                        ResultString += '<input class="form-control"   readonly   name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].FLOAT" type="number"   value="' + v.FLOAT + '" placeholder="Enter Indicator Percentage %"  required />'
                        HiddenValue += '<input   readonly  name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].IndicatorDataType_ID"  value="' + v.InsightIndicatorDataType_ID + '" type="text"   style="display:none;" />'
                    } else if (v.InsightIndicatorDataType_ID == 4) {
                        ResultString += '<select class="form-control"  readonly   name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].BOOL" required >'
                        ResultString += '<option value="">Select Yes/No</option>'
                        ResultString += '<option value="true">Yes</option>'
                        ResultString += '<option value="false">No</option>'
                        ResultString += '</select>'
                        HiddenValue += '<input  readonly    name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].IndicatorDataType_ID"  value="' + v.InsightIndicatorDataType_ID + '" type="text"   style="display:none;" />'
                    } 
                    ResultString += '</td> ';
                    HiddenValue += '</td>';




                    var IndicatorFeedback = '';
                    IndicatorFeedback = '<td>';
                    IndicatorFeedback += '<select class="form-control" name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].Remarks" required >'
                    IndicatorFeedback += '<option value="">Select Option</option>'
                    IndicatorFeedback += '<option value="true">Satisfied</option>'
                    IndicatorFeedback += '<option value="false">Non-Satisfied</option>'
                    IndicatorFeedback += '</select>'
                    IndicatorFeedback += '</td> ';
                   
                    // IndicatorFeedback += '<input  class="form-control"    name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].Feedback"         type="text"  placeholder="Enter Feedback" required />'
                    var IndicatorRemarks = '';
                    IndicatorRemarks = '<td>';
                    IndicatorRemarks += '<input  class="form-control"    name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].Remarks"        type="text"  placeholder="Enter Remarks" required />'
                    IndicatorRemarks += '</td> ';


                    $('<tr id="tblInsightIndicatorRow' + loop + '">' +
                         
                        '<td>' +  counter + '</td>' +
                        InsightIndicatorFieldID +
                        '<td>' + v.InsightIndicatorFieldName + '</td>' +
                        ResultString +
                        IndicatorFeedback +
                        IndicatorRemarks +
                        HiddenValue +
                        '</tr>').appendTo('#tblInsightIndicator');
                    counter++;
                    loop++;
                });
                //END

            }//END Evaluation

            debugger;
            if (response.IsChangeManagementForm == "ChangeManagementForm") {
                $("#tblBodyChangeManagement").empty();

                var counter = 1;
                var loop = 0;
                //KPIS
                $.each(response.ListOfChangeManagements, function (index, v) {
                    /// do stuff

                    debugger;
                    var ProjectID = '<td style="display:none";><input  name="ListOfChangeManagements[' + loop + '].ProjectID"  value="' + v.ProjectID + '" type="text"  /></td>';  //Hidden
                    var SubProjectID = '<td style="display:none";><input  name="ListOfChangeManagements[' + loop + '].SubProjectID"  value="' + v.SubProjectID + '" type="text"  /></td>';  //Hidden

                    var ItemName = '';
                    ItemName = '<td>';
                    ItemName += '<input  class="form-control "    readonly name="ListOfChangeManagements[' + loop + '].ItemName"    value="' + v.ItemName + '"      type="text"  placeholder="Enter Indicator Description" required />'
                    ItemName += '</td> ';

                    var CurrentValue = '';
                    CurrentValue = '<td>';
                    CurrentValue += '<input class="form-control "    readonly name="ListOfChangeManagements[' + loop + '].CurrentValue"  value="' + v.CurrentValue + '"  type="number"  placeholder="Enter CurrentValue" required />'
                    CurrentValue += '</td> ';

                    var ChangeValue = '';
                    ChangeValue = '<td>';
                    ChangeValue += '<input class="form-control"    name="ListOfChangeManagements[' + loop + '].ChangeValue"  value="' + v.ChangeValue + '"  type="text"  placeholder="Enter ChangeValue" required />'
                    ChangeValue += '</td> ';

                    var Decision = '';
                    Decision = '<td>';
                    Decision += '<input class="form-control"    name="ListOfChangeManagements[' + loop + '].Decision"   type="text"  placeholder="Enter Decision" required />'
                    Decision += '</td> ';

                    var ActionTaken = '';
                    ActionTaken = '<td>';
                    ActionTaken += '<input class="form-control"    name="ListOfChangeManagements[' + loop + '].ActionTaken"   type="text"  placeholder="Enter ActionTaken" required />'
                    ActionTaken += '</td> ';

                    //TABLE INSERTION
                    $('<tr id="tblChangeManagementRow' + loop + '">' +
                        '<td>' + counter + '</td>' +
                        ProjectID +
                        SubProjectID +
                        ItemName +
                        CurrentValue +
                        ChangeValue +
                        Decision +
                        ActionTaken +
                        '</tr>').appendTo('#tblChangeManagement');
                    counter++;
                    loop++;
                });


            }


        },
        error: function (ex) {
            debugger;
            console.log('Failed to Retrieve Data:  ' + ex.responseText);
        }
    });//Ajax_End
});










