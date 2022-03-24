﻿//ALL
$(document).ready(function () {
    $("#RecruitedHR").val('');
    $("#NoOfProcurement").val('');
    $("#ReleasedBudget").val('');
    $("#ExpenditureBudget").val('');
    $("#SubProject_ID").prop("disabled", true);
    $("#Batch_ID").prop("disabled", true);
});

$("#Project_ID").on('change', function () {
    debugger;
    var Url_Value = $('#ProjectComboLink').attr('url-Val');

    var _Project_ID = $("#Project_ID").find("option:selected").val();
    $.ajax({
        type: 'POST',
        url: Url_Value,
        dataType: 'json',
        data: { ProjectID: _Project_ID },
        success: function (response) {
            $("#Batch_ID").empty();
            $("#SubProject_ID").empty();

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
            }else {
                $("#Batch_ID").prop("disabled", false);
                $.each(response.comboBatches, function (i, item) {
                    $("#Batch_ID").append('<option value="' + item.BatchID + '">' +
                        item.BatchName + '</option>');
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
            /* }*/
        },
        error: function (ex) {
            debugger;
            console.log('Failed to Retrieve Data:  ' + ex.responseText);
        }
    });//Ajax_End
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

// $("#SubProject_ID").on('change', function () {
//    var obj = {};
//    obj.Project_ID = $("#Project_ID").find("option:selected").val();
//    obj.SubProject_ID = $("#SubProject_ID").find("option:selected").val();

//    //var Stock = { Project_ID: $("#Project_ID").find("option:selected").val(), Batch_ID: $("#Batch_ID").find("option:selected").val() };
//    $.ajax({
//        type: 'POST',
//        url: '@Url.Action("ClickBatchComboBox", "Common")',
//        data: JSON.stringify(obj),
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',

//        success: function (ProcurementHeadLst) {
//            debugger;
//            $("#PlannedProcurement_ID").empty();
//            if (ProcurementHeadLst.length <= 1 || ProcurementHeadLst == null) {
//                $("#PlannedProcurement_ID").prop("disabled", true);
//                $("#PlannedProcurement_ID").append('<option value="' + 0 + '">' +
//                    "Please Select Procurement Head" + '</option>');
//            } else {
//                $("#PlannedProcurement_ID").prop("disabled", false);
//                $.each(ProcurementHeadLst, function (i, Aqib) {
//                    $("#PlannedProcurement_ID").append('<option value="' + Aqib.PlannedProcurementID + '">' +
//                        Aqib.ProcrumetHeader + '</option>');
//                });
//            }
//            debugger;
//            //RemainingVaues

//            $("#PlannedProcrumentNo").val('');
//            $("#lblRemainingProcurement").text(response.remainingValues.RemainingProcurement);
//            $("#hdnRemainingProcurement").val(response.remainingValues.RemainingProcurement); //Hidden
//        },
//        error: function (ex) {
//            console.log('Failed to Retrieve Indicator Data:  ' + ex.responseText);
//        }
//    });//Ajax_End
//});






