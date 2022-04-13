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
                $('<tr><td>' + counter2 + '</td><td>' + v.InsightIndicatorFieldName + '</td><td>' + v.CommonValue + '</td></tr>').appendTo('#tbInsightlIndicator2');
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

            if (response.IsChangeManagementForm == "ChangeManagementForm") {
                $("#tblBodyChangeManagementProject").empty();
                $("#tblBodyChangeManagementSchedule").empty();
                $("#tblChangeManagemenPlannedKPIs").empty();
                $("#tblBodyChangeManagementPlannedProcurement").empty();


                Common(response);
            }

        }
    });//Ajax_End
});
 
$("#Project_ID").on('change', function () {
 
   
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
       
            $("#Batch_ID").empty();
            $("#SubProject_ID").empty();
            $("#InsightIndicator_ID").empty();
            
     
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

            //ComboSubProject
            if (response.comboProcurementHeads.length <= 1) {
                $("#PlannedProcurement_ID").prop("disabled", true);
                $("#PlannedProcurement_ID").append('<option value="' + 0 + '">' +
                    "Please Select Header" + '</option>');
            } else {
                $("#PlannedProcurement_ID").prop("disabled", false);
                $.each(response.comboProcurementHeads, function (i, item) {
                    $("#PlannedProcurement_ID").append('<option value="' + item.PlannedProcurementID + '">' +
                        item.ProcrumetHeader + '</option>');
                });
            }
            //END

            //EvaulationList      batchIndicatorVM.InsightIndicatorForEvaulationList
            if (response.IsEvaluationForm == "Evaluation") {

                $("#tblBodyKPIs").empty();
                $("#tblBodyInsightIndicator").empty();
                $("#tblBodyChangeManagementPlannedKPIs").empty();
                $("#tblBodyChangeManagementPlannedProcurement").empty();

                var counter = 1;
                var loop = 0;
                //KPIS
                $.each(response.ListOfInsightIndicatorAndKPIs.ListKPIs, function (index, v) {
                    /// do stuff

   
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
                    Feedback += '<option value="NonSatisfied">Non-Satisfied</option>'
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
                    IndicatorFeedback += '<select class="form-control" name="ListOfInsightIndicatorAndKPIs.ListInsightIndicator[' + loop + '].Feedback" required >'
                    IndicatorFeedback += '<option value="">Select Option</option>'
                    IndicatorFeedback += '<option value="Satisfied">Satisfied</option>'
                    IndicatorFeedback += '<option value="NonSatisfied">Non-Satisfied</option>'
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
        
            if (response.IsChangeManagementForm == "ChangeManagementForm") {
             

          
                Common(response);
            }
        },
        error: function (ex) {
            debugger;
            console.log('Failed to Retrieve Data:  ' + ex.responseText);
        }


    });//Ajax_End
});


function RemoveDemerits(row) {
    $(row).parent().parent().remove();
}


function Common(response) {
    debugger;
    $("#tblBodyChangeManagementProject").empty();
    $("#tblBodyChangeManagementSchedule").empty();
    $("#tblChangeManagemenPlannedKPIs").empty();
    $("#tblBodyChangeManagementPlannedProcurement").empty();

    var counter = 1;
    var loop = 0;
    //ProjectList
    $.each(response.ListOfChangeManagementVM.Change_ManagementProjectList, function (index, v) {
        /// do stuff

        var ProjectID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].ProjectID"  value="' + v.ProjectID + '" type="text"  /></td>';  //Hidden
        var SubProjectID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].SubProjectID"  value="' + v.SubProjectID + '" type="text"  /></td>';  //Hidden

        //Row1
        var PlannedBudget = '';
        PlannedBudget = '<td>';
        PlannedBudget += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].PlannedBudget"    value="' + v.PlannedBudget + '"      type="text"   required />'
        PlannedBudget += '</td> ';
        var C_PlannedBudgetValue = '';
        C_PlannedBudgetValue = '<td>';
        C_PlannedBudgetValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].PlannedBudgetValue"  value="' + v.PlannedBudgetValue + '"  type="number"  required />'
        C_PlannedBudgetValue += '</td> ';
        var ChangeValuePlannedBudget = '';
        ChangeValuePlannedBudget = '<td>';
        ChangeValuePlannedBudget += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].ChangeValuePlannedBudget"    type="number"  placeholder="Enter Change Value" required />'
        ChangeValuePlannedBudget += '</td> ';
        var DecisionPlannedBudget = '';
        DecisionPlannedBudget = '<td>';
        DecisionPlannedBudget += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].DecisionPlannedBudget"   type="text"  placeholder="Enter Decision" required />'
        DecisionPlannedBudget += '</td> ';
        var ActionTakenPlannedBudget = '';
        ActionTakenPlannedBudget = '<td>';
        ActionTakenPlannedBudget += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].ActionTakenPlannedBudget"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenPlannedBudget += '</td> ';

        //Row2
        var ApprovedBudget = '';
        ApprovedBudget = '<td>';
        ApprovedBudget += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].ApprovedBudget"    value="' + v.ApprovedBudget + '"      type="text"   required />'
        ApprovedBudget += '</td> ';
        var ApprovedBudgetValue = '';
        ApprovedBudgetValue = '<td>';
        ApprovedBudgetValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].ApprovedBudgetValue"  value="' + v.ApprovedBudgetValue + '"  type="number"  required />'
        ApprovedBudgetValue += '</td> ';
        var ChangeValueApprovedBudget = '';
        ChangeValueApprovedBudget = '<td>';
        ChangeValueApprovedBudget += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].ChangeValueApprovedBudget"   type="number"  placeholder="Enter Change Value" required />'
        ChangeValueApprovedBudget += '</td> ';
        var DecisionApprovedBudget = '';
        DecisionApprovedBudget = '<td>';
        DecisionApprovedBudget += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].DecisionApprovedBudget"   type="text"  placeholder="Enter Decision" required />'
        DecisionApprovedBudget += '</td> ';
        var ActionTakenApprovedBudget = '';
        ActionTakenApprovedBudget = '<td>';
        ActionTakenApprovedBudget += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].ActionTakenApprovedBudget"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenApprovedBudget += '</td> ';

        //Row3
        var PlannedHR = '';
        PlannedHR = '<td>';
        PlannedHR += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].PlannedHR"    value="' + v.PlannedHR + '"      type="text"   required />'
        PlannedHR += '</td> ';
        var PlannedHRValue = '';
        PlannedHRValue = '<td>';
        PlannedHRValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].PlannedHRValue"  value="' + v.PlannedHRValue + '"  type="number"  required />'
        PlannedHRValue += '</td> ';
        var ChangeValuePlannedHR = '';
        ChangeValuePlannedHR = '<td>';
        ChangeValuePlannedHR += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].ChangeValuePlannedHR"  value="' + v.ChangeValuePlannedHR + '"  type="number"  placeholder="Enter Change Value" required />'
        ChangeValuePlannedHR += '</td> ';
        var DecisionPlannedHR = '';
        DecisionPlannedHR = '<td>';
        DecisionPlannedHR += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].DecisionPlannedHR"   type="text"  placeholder="Enter Decision" required />'
        DecisionPlannedHR += '</td> ';
        var ActionTakenPlannedHR = '';
        ActionTakenPlannedHR = '<td>';
        ActionTakenPlannedHR += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementProjectList[' + loop + '].ActionTakenPlannedHR"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenPlannedHR += '</td> ';

        debugger;
        //TABLE INSERTION  >PROJECT

        $('<tr id="tblChangeManagementProjectRow' + loop + '">' +
            ProjectID +
            SubProjectID +
            PlannedBudget +
            C_PlannedBudgetValue +
            ChangeValuePlannedBudget +
            DecisionPlannedBudget +
            ActionTakenPlannedBudget +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>' +
            '<tr>' +
            ProjectID +
            SubProjectID +
            ApprovedBudget +
            ApprovedBudgetValue +
            ChangeValueApprovedBudget +
            DecisionApprovedBudget +
            ActionTakenApprovedBudget +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>' +
            '<tr>' +
            ProjectID +
            SubProjectID +
            PlannedHR +
            PlannedHRValue +
            ChangeValuePlannedHR +
            DecisionPlannedHR +
            ActionTakenPlannedHR +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>').appendTo('#tblChangeManagementProject');
        counter++;
        loop++;
    });

    debugger;
    var counter2 = 1;
    var loop2 = 0;
    //ScheduleList
    $.each(response.ListOfChangeManagementVM.Change_ManagementScheduleList, function (index, v) {
        /// do stuff
        var ProjectID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].Project_ID"  value="' + v.Project_ID + '" type="text"  /></td>';  //Hidden
        var SubProjectID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].SubProject_ID"  value="' + v.SubProject_ID + '" type="text"  /></td>';  //Hidden
        var ScheduleID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].ScheduleID"  value="' + v.ScheduleID + '" type="text"  /></td>';  //Hidden
        //TABLE
        //Row2

        var PlannedDate = '';
        PlannedDate = '<td>';
        PlannedDate += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].PlannedDate"    value="' + v.PlannedDate + '"      type="text"   required />'
        PlannedDate += '</td> ';
        var PlannedDateValue = '';
        PlannedDateValue = '<td>';
        PlannedDateValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].PlannedDateValue"  value="' + v.PlannedDateValue + '"  type="text"  required />'
        PlannedDateValue += '</td> ';
        var ChangeValuePlannedDate = '';
        ChangeValuePlannedDate = '<td>';
        ChangeValuePlannedDate += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].ChangeValuePlannedDate"  value="' + v.ChangeValuePlannedDate + '"  type="date"  placeholder="Enter Change Value" required />'
        ChangeValuePlannedDate += '</td> ';
        var DecisionPlannedDate = '';
        DecisionPlannedDate = '<td>';
        DecisionPlannedDate += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].DecisionPlannedDate"   type="text"  placeholder="Enter Decision" required />'
        DecisionPlannedDate += '</td> ';
        var ActionTakenPlannedDate = '';
        ActionTakenPlannedDate = '<td>';
        ActionTakenPlannedDate += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].ActionTakenPlannedDate"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenPlannedDate += '</td> ';

        //Row2
        var StartDate = '';
        StartDate = '<td>';
        StartDate += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].StartDate"    value="' + v.StartDate + '"      type="text"   required />'
        StartDate += '</td> ';
        var StartDateValue = '';
        StartDateValue = '<td>';
        StartDateValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].StartDateValue"  value="' + v.StartDateValue + '"  type="text"  required />'
        StartDateValue += '</td> ';
        var ChangeValueStartDate = '';
        ChangeValueStartDate = '<td>';
        ChangeValueStartDate += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].ChangeValueStartDate"  value="' + v.ChangeValueStartDate + '"  type="date"  placeholder="Enter Change Value" required />'
        ChangeValueStartDate += '</td> ';
        var DecisionStartDate = '';
        DecisionStartDate = '<td>';
        DecisionStartDate += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].DecisionStartDate"   type="text"  placeholder="Enter Decision" required />'
        DecisionStartDate += '</td> ';
        var ActionTakenStartDate = '';
        ActionTakenStartDate = '<td>';
        ActionTakenStartDate += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].ActionTakenStartDate"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenStartDate += '</td> ';

        //Row3
        var EndDate = '';
        EndDate = '<td>';
        EndDate += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].EndDate"    value="' + v.EndDate + '"      type="text"   required />'
        EndDate += '</td> ';
        var EndDateValue = '';
        EndDateValue = '<td>';
        EndDateValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].EndDateValue"  value="' + v.EndDateValue + '"  type="text"  required />'
        EndDateValue += '</td> ';
        var ChangeValueEndDate = '';
        ChangeValueEndDate = '<td>';
        ChangeValueEndDate += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].ChangeValueEndDate"  value="' + v.ChangeValueEndDate + '"  type="date"  placeholder="Enter Change Value" required />'
        ChangeValueEndDate += '</td> ';
        var DecisionEndDate = '';
        DecisionEndDate = '<td>';
        DecisionEndDate += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].DecisionEndDate"   type="text"  placeholder="Enter Decision" required />'
        DecisionEndDate += '</td> ';
        var ActionTakenEndDate = '';
        ActionTakenEndDate = '<td>';
        ActionTakenEndDate += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementScheduleList[' + loop2 + '].ActionTakenEndDate"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenEndDate += '</td> ';




        //TABLE INSERTION  >PROJECT
        $('<tr id="tblChangeManagementScheduleRow' + loop2 + '">' +
            ProjectID +
            SubProjectID +
            ScheduleID +
            PlannedDate +
            PlannedDateValue +
            ChangeValuePlannedDate +
            DecisionPlannedDate +
            ActionTakenPlannedDate +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>' +
            '<tr>' +
            ProjectID +
            SubProjectID +
            ScheduleID +
            StartDate +
            StartDateValue +
            ChangeValueStartDate +
            DecisionStartDate +
            ActionTakenStartDate +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>' +
            '<tr>' +
            ProjectID +
            SubProjectID +
            ScheduleID +
            EndDate +
            EndDateValue +
            ChangeValueEndDate +
            DecisionEndDate +
            ActionTakenEndDate +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>').appendTo('#tblChangeManagementSchedule');
        counter2++;
        loop2++;
    });

    var counter3 = 1;
    var loop3 = 0;
    //PlannedKPIList
    $.each(response.ListOfChangeManagementVM.Change_ManagementPlannedKPIList, function (index, v) {
        /// do stuff
        var ProjectID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].Project_ID"  value="' + v.Project_ID + '" type="text"  /></td>';  //Hidden
        var SubProjectID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].SubProject_ID"  value="' + v.SubProject_ID + '" type="text"  /></td>';  //Hidden
        var PlannedKPIsID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].PlannedKPIsID"  value="' + v.PlannedKPIsID + '" type="text"  /></td>';  //Hidden

        //TABLE
        //Row1
        var IndicatorDescription = '';
        IndicatorDescription = '<td>';
        IndicatorDescription += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].IndicatorDescription"    value="' + v.IndicatorDescription + '"      type="text"   required />'
        IndicatorDescription += '</td> ';
        var IndicatorDescriptionValue = '';
        IndicatorDescriptionValue = '<td>';
        IndicatorDescriptionValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].IndicatorDescriptionValue"  value="' + v.IndicatorDescriptionValue + '"  type="text"  required />'
        IndicatorDescriptionValue += '</td> ';
        var ChangeValueIndicatorDescription = '';
        ChangeValueIndicatorDescription = '<td>';
        ChangeValueIndicatorDescription += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].ChangeValueIndicatorDescription"   type="text"  placeholder="Enter Change Value" required />'
        ChangeValueIndicatorDescription += '</td> ';
        var DecisionIndicatorDescription = '';
        DecisionIndicatorDescription = '<td>';
        DecisionIndicatorDescription += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].DecisionIndicatorDescription"   type="text"  placeholder="Enter Decision" required />'
        DecisionIndicatorDescription += '</td> ';
        var ActionTakenIndicatorDescription = '';
        ActionTakenIndicatorDescription = '<td>';
        ActionTakenIndicatorDescription += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].ActionTakenIndicatorDescription"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenIndicatorDescription += '</td> ';

        //Row2
        var Target = '';
        Target = '<td>';
        Target += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].Target"    value="' + v.Target + '"      type="text"   required />'
        Target += '</td> ';
        var TargetValue = '';
        TargetValue = '<td>';
        TargetValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].TargetValue"  value="' + v.TargetValue + '"  type="number"  required />'
        TargetValue += '</td> ';
        var ChangeValueTarget = '';
        ChangeValueTarget = '<td>';
        ChangeValueTarget += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].ChangeValueTarget"  type="number"  placeholder="Enter Change Value" required />'
        ChangeValueTarget += '</td> ';
        var DecisionTarget = '';
        DecisionTarget = '<td>';
        DecisionTarget += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].DecisionTarget"   type="text"  placeholder="Enter Decision" required />'
        DecisionTarget += '</td> ';
        var ActionTakenTarget = '';
        ActionTakenTarget = '<td>';
        ActionTakenTarget += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].ActionTakenTarget"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenTarget += '</td> ';

        //Row3
        var TimeLine = '';
        TimeLine = '<td>';
        TimeLine += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].TimeLine"    value="' + v.TimeLine + '"      type="text"   required />'
        TimeLine += '</td> ';
        var TimeLineValue = '';
        TimeLineValue = '<td>';
        TimeLineValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].TimeLineValue"  value="' + v.TimeLineValue + '"  type="text"  required />'
        TimeLineValue += '</td> ';
        var ChangeValueTimeLine = '';
        ChangeValueTimeLine = '<td>';
        ChangeValueTimeLine += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].ChangeValueTimeLine"  value="' + v.ChangeValueTimeLine + '"  type="date"  placeholder="Enter Change Value" required />'
        ChangeValueTimeLine += '</td> ';
        var DecisionTimeLine = '';
        DecisionTimeLine = '<td>';
        DecisionTimeLine += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].DecisionTimeLine"   type="text"  placeholder="Enter Decision" required />'
        DecisionTimeLine += '</td> ';
        var ActionTakenTimeLine = '';
        ActionTakenTimeLine = '<td>';
        ActionTakenTimeLine += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedKPIList[' + loop3 + '].ActionTakenTimeLine"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenTimeLine += '</td> ';

        //TABLE INSERTION  >PlannedKPI

        $('<tr id="tblChangeManagementPlannedKPIRow' + loop3 + '">' +
            ProjectID +
            SubProjectID +
            PlannedKPIsID +
            IndicatorDescription +
            IndicatorDescriptionValue +
            ChangeValueIndicatorDescription +
            DecisionIndicatorDescription +
            ActionTakenIndicatorDescription +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>' +
            '<tr>' +
            ProjectID +
            SubProjectID +
            PlannedKPIsID +
            Target +
            TargetValue +
            ChangeValueTarget +
            DecisionTarget +
            ActionTakenTarget +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>' +
            '<tr>' +
            ProjectID +
            SubProjectID +
            PlannedKPIsID +
            TimeLine +
            TimeLineValue +
            ChangeValueTimeLine +
            DecisionTimeLine +
            ActionTakenTimeLine +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>').appendTo('#tblChangeManagemenPlannedKPIs');
        counter3++;
        loop3++;
    });

    var counter4 = 1;
    var loop4 = 0;
    //PlannedKPIList
    $.each(response.ListOfChangeManagementVM.Change_ManagementPlannedProcurementList, function (index, v) {
        /// do stuff
        var ProjectID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].Project_ID"  value="' + v.Project_ID + '" type="text"  /></td>';  //Hidden
        var SubProjectID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].SubProject_ID"  value="' + v.SubProject_ID + '" type="text"  /></td>';  //Hidden
        var PlannedProcurementID = '<td style="display:none";><input  name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].PlannedProcurementID"  value="' + v.PlannedProcurementID + '" type="text"  /></td>';  //Hidden

        //TABLE
        //Row1
        var ProcrumetHeader = '';
        ProcrumetHeader = '<td>';
        ProcrumetHeader += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].ProcrumetHeader"    value="' + v.ProcrumetHeader + '"      type="text"   required />'
        ProcrumetHeader += '</td> ';
        var ProcrumetHeaderValue = '';
        ProcrumetHeaderValue = '<td>';
        ProcrumetHeaderValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].ProcrumetHeaderValue"  value="' + v.ProcrumetHeaderValue + '"  type="text"  required />'
        ProcrumetHeaderValue += '</td> ';
        var ChangeValueProcrumetHeader = '';
        ChangeValueProcrumetHeader = '<td>';
        ChangeValueProcrumetHeader += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].ChangeValueProcrumetHeader"   type="number"  placeholder="Enter Change Value" required />'
        ChangeValueProcrumetHeader += '</td> ';
        var DecisionProcrumetHeader = '';
        DecisionProcrumetHeader = '<td>';
        DecisionProcrumetHeader += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].DecisionProcrumetHeader"   type="text"  placeholder="Enter Decision" required />'
        DecisionProcrumetHeader += '</td> ';
        var ActionTakenProcrumetHeader = '';
        ActionTakenProcrumetHeader = '<td>';
        ActionTakenProcrumetHeader += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].ActionTakenProcrumetHeader"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenProcrumetHeader += '</td> ';

        //Row2
        var PlannedProcrumentNo = '';
        PlannedProcrumentNo = '<td>';
        PlannedProcrumentNo += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].PlannedProcrumentNo"    value="' + v.PlannedProcrumentNo + '"      type="text"   required />'
        PlannedProcrumentNo += '</td> ';
        var PlannedProcrumentNoValue = '';
        PlannedProcrumentNoValue = '<td>';
        PlannedProcrumentNoValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].PlannedProcrumentNoValue"  value="' + v.PlannedProcrumentNoValue + '"  type="number"  required />'
        PlannedProcrumentNoValue += '</td> ';
        var ChangeValuePlannedProcrumentNo = '';
        ChangeValuePlannedProcrumentNo = '<td>';
        ChangeValuePlannedProcrumentNo += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].ChangeValuePlannedProcrumentNo"  type="number"  placeholder="Enter Change Value" required />'
        ChangeValuePlannedProcrumentNo += '</td> ';
        var DecisionPlannedProcrumentNo = '';
        DecisionPlannedProcrumentNo = '<td>';
        DecisionPlannedProcrumentNo += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].DecisionPlannedProcrumentNo"   type="text"  placeholder="Enter Decision" required />'
        DecisionPlannedProcrumentNo += '</td> ';
        var ActionTakenPlannedProcrumentNo = '';
        ActionTakenPlannedProcrumentNo = '<td>';
        ActionTakenPlannedProcrumentNo += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].ActionTakenPlannedProcrumentNo"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenPlannedProcrumentNo += '</td> ';

        //Row3
        var PlannedPerCostItem = '';
        PlannedPerCostItem = '<td>';
        PlannedPerCostItem += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].PlannedPerCostItem"    value="' + v.PlannedPerCostItem + '"      type="text"   required />'
        PlannedPerCostItem += '</td> ';
        var PlannedPerCostItemValue = '';
        PlannedPerCostItemValue = '<td>';
        PlannedPerCostItemValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].PlannedPerCostItemValue"  value="' + v.PlannedPerCostItemValue + '"  type="number"  required />'
        PlannedPerCostItemValue += '</td> ';
        var ChangeValuePlannedPerCostItem = '';
        ChangeValuePlannedPerCostItem = '<td>';
        ChangeValuePlannedPerCostItem += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].ChangeValuePlannedPerCostItem"  value="' + v.ChangeValuePlannedPerCostItem + '"  type="number"  placeholder="Enter Change Value" required />'
        ChangeValuePlannedPerCostItem += '</td> ';
        var DecisionPlannedPerCostItem = '';
        DecisionPlannedPerCostItem = '<td>';
        DecisionPlannedPerCostItem += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].DecisionPlannedPerCostItem"   type="text"  placeholder="Enter Decision" required />'
        DecisionPlannedPerCostItem += '</td> ';
        var ActionTakenPlannedPerCostItem = '';
        ActionTakenPlannedPerCostItem = '<td>';
        ActionTakenPlannedPerCostItem += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].ActionTakenPlannedPerCostItem"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenPlannedPerCostItem += '</td> ';

        //Row4
        var AchivedCost = '';
        AchivedCost = '<td>';
        AchivedCost += '<input  class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].AchivedCost"    value="' + v.AchivedCost + '"      type="text"   required />'
        AchivedCost += '</td> ';
        var AchivedCostValue = '';
        AchivedCostValue = '<td>';
        AchivedCostValue += '<input class="form-control "    readonly name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].AchivedCostValue"  value="' + v.AchivedCostValue + '"  type="number"  required />'
        AchivedCostValue += '</td> ';
        var ChangeValueAchivedCost = '';
        ChangeValueAchivedCost = '<td>';
        ChangeValueAchivedCost += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].ChangeValueAchivedCost"  value="' + v.ChangeValueAchivedCost + '"  type="number"  placeholder="Enter Change Value" required />'
        ChangeValueAchivedCost += '</td> ';
        var DecisionAchivedCost = '';
        DecisionAchivedCost = '<td>';
        DecisionAchivedCost += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].DecisionAchivedCost"   type="text"  placeholder="Enter Decision" required />'
        DecisionAchivedCost += '</td> ';
        var ActionTakenAchivedCost = '';
        ActionTakenAchivedCost = '<td>';
        ActionTakenAchivedCost += '<input class="form-control"    name="ListOfChangeManagementVM.Change_ManagementPlannedProcurementList[' + loop4 + '].ActionTakenAchivedCost"   type="text"  placeholder="Enter ActionTaken" required />'
        ActionTakenAchivedCost += '</td> ';

        //TABLE INSERTION  >PlannedProcurement

        $('<tr id="tblChangeManagemenPlannedProcurementRow' + loop4 + '">' +
            ProjectID +
            SubProjectID +
            PlannedProcurementID +
            ProcrumetHeader +
            ProcrumetHeaderValue +
            ChangeValueProcrumetHeader +
            DecisionProcrumetHeader +
            ActionTakenProcrumetHeader +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>' +
            '<tr>' +
            ProjectID +
            SubProjectID +
            PlannedProcurementID +
            PlannedProcrumentNo +
            PlannedProcrumentNoValue +
            ChangeValuePlannedProcrumentNo +
            DecisionPlannedProcrumentNo +
            ActionTakenPlannedProcrumentNo +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>' +
            '<tr>' +
            ProjectID +
            SubProjectID +
            PlannedProcurementID +
            PlannedPerCostItem +
            PlannedPerCostItemValue +
            ChangeValuePlannedPerCostItem +
            DecisionPlannedPerCostItem +
            ActionTakenPlannedPerCostItem +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>' +
            '<tr>' +
            ProjectID +
            SubProjectID +
            PlannedProcurementID +
            AchivedCost +
            AchivedCostValue +
            ChangeValueAchivedCost +
            DecisionAchivedCost +
            ActionTakenAchivedCost +
            "<td><a href='javascript:void(0);' class='remCF2' onClick='RemoveDemerits(this);'>Remove</a></td>" +
            '</tr>').appendTo('#tblChangeManagemenPlannedProcurement');
        counter4++;
        loop4++;
    });

}





