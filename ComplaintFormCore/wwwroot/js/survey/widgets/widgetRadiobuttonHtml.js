﻿//  This is to open the additional information div when a checkbox is being checked or hide it when the checkbox is un-checked.
//  It will also remove or add the item being chekced or unchecked from the json data
function radioButtonInfoPopup(elem) {

    var parent = $(elem).closest("div");
    var data = survey.data;

    $(".info-popup").hide();

    if ($(elem).is(':checked')) {
        parent.find(".info-popup").show();

        //  If the array object of the checkbox list is not set the create it
        if (!data[elem.name]) {
            data[elem.name] = [];
        }

        //  push the selected value
        data[elem.name].push(elem.value);

    }
    else {

        //parent.find(".info-popup").hide();

        //  removing the un-checked item from the json object
        for (var i = 0; i < data[elem.name].length; i++) {
            if (data[elem.name][i] === elem.value) {
                data[elem.name].splice(i, 1);
            }
        }
    }

    survey.data = data;
}

(function () {

    var widget = {
        //the widget name. It should be unique and written in lowcase.
        name: "radiobuttonwithhtmlinfo",
        //the widget title. It is how it will appear on the toolbox of the SurveyJS Editor/Builder
        title: "Radio button list with addtional Html info",
        iconName: "",

        widgetIsLoaded: function () {
            //If the widgets depends on third-party library(s) then here you may check if this library(s) is loaded
            return true;
        },

        isFit: function (question) {
            //  This is a match for checkboxes that have addtionnal Html information to show when an item is clicked and not in 'preview' mode
            return question.getType() === 'radiogroup' && question.hasHtmlAddtionalInfo && !question.isReadOnly;
        },

        activatedByChanged: function (activatedBy) {

            //  Add the new property 'hasHtmlInfo' at the checkbox level to indication that
            //  this is a kind of checkbox with additionnal information displayed as html
            Survey.JsonObject.metaData.addProperties("radiogroup", [
                {
                    name: "hasHtmlAddtionalInfo", default: false
                }
            ]);
        },

        isDefaultRender: false,
        htmlTemplate: "<div></div>",

        //The main function, rendering and two-way binding
        afterRender: function (question, el) {

            var rootWidget = this;
            var outputHTML = "";

            outputHTML += "<fieldset class='sv_qcbc form-group'><legend aria-label=\"<span class='sv_q_required_text'>&ast;</span>" + question.title + "\"></legend>";
            //                                                  <legend aria-label="<span class='sv_q_required_text'> </span>L’institution ?"></legend> good
            //                                                  <legend aria-label="<span class=" sv_q_required_text'=""> L’institution?'&gt;</legend> wrong
            //  This is where each radio button items are being created

            question.choices.forEach(function (row, index, rows) {

                //  the checked flag is based on incoming (or existing) json data
                var isChecked = false;
                if (question.data && question.data.data && question.data.data[question.name] && question.data.data[question.name] == row.value) {
                    isChecked = true;
                }

                outputHTML += "<div class='sv_q_radiogroup " + (isChecked == true ? 'checked' : "undefined") + " sv-q-col-1'>"
                outputHTML += "<label class='sv_q_radiogroup_label'>";
                outputHTML += "<input type='radio' name='" + question.name + "' value='" + row.value + "' role='radio' aria-required='true' aria-label='" + row.text + "' class='sv_q_radiogroup_control_item checkbox-info-popup-trigger' onclick='radioButtonInfoPopup(this)' />";

               // outputHTML += "<span class='circle'><svg viewBox = '-12 -12 24 24' class='sv-hidden'><circle r='6' cx='0' cy='0'></circle></svg></span>";
                outputHTML += "<span class='checkbox-material'><span class='check'></span></span ><span class='sv_q_checkbox_control_label'><span style='position: static;'><span style='position: static;'>" + row.text + "</span></span></span>";
                outputHTML += "</label>";

                //  question.isReadOnly means we are in 'Preview' mode so we don't want to display the additional information in preview
                if (!question.isReadOnly && row.htmlAdditionalInfo) {

                    //  This is where we are adding the additionnal information. 
                    //  Putting the <div> wrapper here is probably better than putting it in the json
                    outputHTML += "<div class='info-popup alert alert-info' style='display: " + (isChecked ? 'block' : 'none') + ";'>";

                    var rowText = "";

                    if (question.survey.locale == 'fr' && row.htmlAdditionalInfo.fr) {
                        rowText = row.htmlAdditionalInfo.fr;
                    }
                    else if (row.htmlAdditionalInfo.en) {
                        rowText = row.htmlAdditionalInfo.en;
                    }
                    else {
                        rowText = row.htmlAdditionalInfo;
                    }

                    outputHTML += rowText;
                    outputHTML += "</div>";
                }

                outputHTML += "</div>";
            });

            outputHTML = outputHTML + "</fieldset>";

            el.innerHTML = outputHTML;
        }
    }

    //Register our widget in singleton custom widget collection
    Survey.CustomWidgetCollection.Instance.addCustomWidget(widget, "customtype");
})();