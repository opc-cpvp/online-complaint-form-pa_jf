﻿var surveyPDF;

var optionsEn = {
    fontSize: 12,
    margins: {
        left: 10,
        right: 10,
        top: 10,
        bot: 10
    },
    format: "a4",
    fontName: 'times',
    fontStyle: 'normal',
    htmlRenderAs: "image",
  
    //pagebreak: { mode: 'avoid-all' }      // this option avoid breaking the survey on an element
    //compress: true
};

var optionsFr = {
    fontSize: 14,
    margins: {
        left: 10,
        right: 10,
        top: 10,
        bot: 10
    },
    format: "a4",
    fontName: 'fontawesome-webfont',
    fontStyle: 'normal',
    base64Normal: 'base64AwesomeFontNormal',
    base64Bold: 'base64AwesomeFontBold',
    htmlRenderAs: "image"
};

function intiSurveyPDF(json, lang) {

    if (lang == 'fr') {
        surveyPDF = new SurveyPDF.SurveyPDF(json, optionsFr);
    }
    else {
        surveyPDF = new SurveyPDF.SurveyPDF(json, optionsEn);
    }    

    var converter = new showdown.Converter();

    surveyPDF
        .onTextMarkdown
        .add(function (survey, options) {
            var str = converter.makeHtml(options.text);
            str = str.substring(3);
            str = str.substring(0, str.length - 4);
            options.html = str;
        });


    surveyPDF
        .onRenderQuestion
        .add(function (survey, options) {

            //if (options.question.name == "text_question") {

            //}

            if (options.question.getType() === "html") {

            }
        });

    surveyPDF
        .onRenderPage
        .add(function (survey, options) {

            var test = options.page.hideOnPreview;
            //if (options.question.name == "text_question") {

            //}
           
        });


    //surveyPDF
    //    .onRenderHeader
    //    .add(function (survey, canvas) {
    //        canvas.drawImage({
    //            base64: 'data:image/png;base64,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',
    //            horizontalAlign: 'left',
    //            width: (canvas.rect.yBot - canvas.rect.yTop) * 0.6,
    //            height: (canvas.rect.yBot - canvas.rect.yTop) * 0.6,
    //            margins: {
    //                left: (canvas.rect.yBot - canvas.rect.yTop) * 0.2
    //            }
    //        });
    //    });
}

function saveSurveyPDF(surveyModel, filename) {

    surveyPDF.data = surveyModel.data;

    var saveType = 'saveAsString';

    if (saveType === "saveAsFile") {

        filename += '_asFile.pdf';
        surveyPDF.save(filename);
    }
    else if (saveType === "saveAsString") {

        filename += '_asString.pdf';
        surveyPDF
            .raw()
            .then(function (text) {
                var file = new Blob([text], { type: "application/pdf" });
               // var file = new Blob([text], { type: "text/plain" });
                var a = document.createElement("a");
                a.href = URL.createObjectURL(file);
                a.download = filename;
                document
                    .body
                    .appendChild(a);
                a.click();
            });
    }
    else if (saveType === "saveAsBlob") {
        filename += '_asBlob.pdf';
        surveyPDF
            .raw("bloburl")
            .then(function (bloburl) {
                var a = document.createElement("a");
                a.href = bloburl;
                a.download = filename;
                document
                    .body
                    .appendChild(a);
                a.click();
            });
    }
    else {
        filename += '_asNothing.pdf';
        var oldFrame = document.getElementById("pdf-preview-frame");
        if (oldFrame)
            oldFrame
                .parentNode
                .removeChild(oldFrame);
        surveyPDF
            .raw("dataurlstring")
            .then(function (dataurl) {
                var pdfEmbed = document.createElement("embed");
                pdfEmbed.setAttribute("id", "pdf-preview-frame");
                pdfEmbed.setAttribute("type", "application/pdf");
                pdfEmbed.setAttribute("style", "width:100%");
                pdfEmbed.setAttribute("height", 200);
                pdfEmbed.setAttribute("src", dataurl);
                var previewDiv = document.getElementById("pdf-preview");
                previewDiv.appendChild(pdfEmbed);
            });
    }
}
