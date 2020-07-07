﻿var widget = {
    //the widget name. It should be unique and written in lowcase.
    name: "checkboxwithhtmlinfo",
    //the widget title. It is how it will appear on the toolbox of the SurveyJS Editor/Builder
    title: "Checkbox list with addtional Html info",
    iconName: "",

    widgetIsLoaded: function () {
            //If the widgets depends on third-party library(s) then here you may check if this library(s) is loaded
        return true;
    },

    isFit: function (question) {
        //  This is a match for checkboxes that have addtionnal Html information to show when an item is clicked and not in 'preview' mode
        return question.getType() === 'checkbox' && question.hasHtmlAddtionalInfo && !question.isReadOnly;
    },

    activatedByChanged: function (activatedBy) {

        //  Add the new property 'hasHtmlInfo' at the checkbox level to indication that
        //  this is a kind of checkbox with additionnal information displayed as html
        Survey.JsonObject.metaData.addProperties("checkbox", [
            {
                name: "hasHtmlAddtionalInfo", default: false
            }
        ]);
    },

    isDefaultRender: false,
    //htmlTemplate: "<div><input /><button></button></div>",

    //The main function, rendering and two-way binding
    afterRender: function (question, el) {

        var outputHTML = "";
        var allCheckboxes = question.choices;

        //  This is where each checkbox item is being created

        allCheckboxes.forEach(function (row, index, rows) {

            //  the checked flag is based on incoming (or existing) json data
            var isChecked = false;
            if (question.data && question.data.data && question.data.data[question.name] && question.data.data[question.name].includes(row.value)) {
                isChecked = true;
            }

            outputHTML += "<div class='sv_q_checkbox sv-q-col-1'>" +
                "   <label class='sv_q_checkbox_label'>" +
                "   <input type='checkbox' name='" + question.name + "' value='" + row.value + "' aria-required='true' aria-label='" + row.text + "' class='sv_q_checkbox_control_item checkbox-info-popup-trigger' onclick='checkBoxInfoPopup(this)' ";

            if (isChecked) {
                outputHTML = outputHTML + " checked "
            }

            outputHTML = outputHTML + "/>";

            outputHTML = outputHTML + "<span class='checkbox-material'><svg viewBox = '0 0 24 24' class='sv-hidden' ><path d='M5,13l2-2l3,3l7-7l2,2l-9,9L5,13z'></path></svg ><span class='check'></span></span >    <span class='sv_q_checkbox_control_label'><span style='position: static;'><span style='position: static;'>" + row.text + "</span></span></span>" +
                "   </label>";

            //  question.isReadOnly means we are in 'Preview' mode so we don't want to display the additional information in preview
            if (!question.isReadOnly && row.htmlAdditionalInfo) {

                //  This is where we are adding the additionnal information. 
                //  Putting the <div> wrapper here is probably better than putting it in the json
                if (isChecked) {
                    outputHTML = outputHTML + "<div class='info-popup alert alert-info' style='display: block;'>" + row.htmlAdditionalInfo + "</div>";
                }
                else {
                    outputHTML = outputHTML + "<div class='info-popup alert alert-info' style='display: none;'>" + row.htmlAdditionalInfo + "</div>";
                }                
            }

            outputHTML = outputHTML + "</div>";

        });

        el.innerHTML = outputHTML;
    }
}

//Register our widget in singleton custom widget collection
Survey.CustomWidgetCollection.Instance.addCustomWidget(widget, "customtype");
