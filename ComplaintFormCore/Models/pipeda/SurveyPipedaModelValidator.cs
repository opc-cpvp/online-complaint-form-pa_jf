﻿using ComplaintFormCore.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintFormCore.Models.pipeda
{
    public class SurveyPipedaModelValidator : AbstractValidator<SurveyPipedaModel>
    {
        public SurveyPipedaModelValidator(SharedLocalizer _localizer)
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Continue;

            // ProvinceIncidence
            RuleFor(x => x.ProvinceIncidence).NotEmpty().WithMessage(_localizer.GetLocalizedStringSharedResource("FieldIsRequired"));
            RuleFor(x => x.ProvinceIncidence).Must(x => new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14" }.Contains(x)).WithMessage(_localizer.GetLocalizedStringSharedResource("SelectedValueNotValid"));

            // ComplaintAboutHandlingInformationOutsideProvince
            RuleFor(x => x.ComplaintAboutHandlingInformationOutsideProvince).NotEmpty().When(x => new List<string> { "2", "6", "9" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("FieldIsRequired"));
            RuleFor(x => x.ComplaintAboutHandlingInformationOutsideProvince).Must(x => new List<string> { "yes", "no", "not_sure" }.Contains(x)).When(x => new List<string> { "2", "6", "9" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("SelectedValueNotValid"));

            // IsAgainstFwub
            RuleFor(x => x.IsAgainstFwub).NotEmpty().When(x => new List<string> { "2", "6", "9" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("FieldIsRequired"));
            RuleFor(x => x.IsAgainstFwub).Must(x => new List<string> { "yes", "no" }.Contains(x)).When(x => new List<string> { "2", "6", "9" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("SelectedValueNotValid"));

            // DidOrganizationDirectComplaintToOpc
            RuleFor(x => x.DidOrganizationDirectComplaintToOpc).NotEmpty().When(x => new List<string> { "2", "6", "9" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("FieldIsRequired"));
            RuleFor(x => x.DidOrganizationDirectComplaintToOpc).Must(x => new List<string> { "yes", "no" }.Contains(x)).When(x => new List<string> { "2", "6", "9" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("SelectedValueNotValid"));

            // ComplaintAgainstHandlingOfInformation
            RuleFor(x => x.ComplaintAgainstHandlingOfInformation).NotEmpty().When(x => new List<string> { "1", "3", "4", "5", "7", "8", "10" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("FieldIsRequired"));
            RuleFor(x => x.ComplaintAgainstHandlingOfInformation).Must(x => new List<string> { "yes", "no" }.Contains(x)).When(x => new List<string> { "1", "3", "4", "5", "7", "8", "10" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("SelectedValueNotValid"));

            // HealthPractitioner
            RuleFor(x => x.HealthPractitioner).NotEmpty().When(x => new List<string> { "1", "3", "4", "5", "7", "8", "10" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("FieldIsRequired"));
            RuleFor(x => x.HealthPractitioner).Must(x => new List<string> { "yes", "no" }.Contains(x)).When(x => new List<string> { "1", "3", "4", "5", "7", "8", "10" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("SelectedValueNotValid"));

            // IndependantPhysicalExam
            RuleFor(x => x.IndependantPhysicalExam).NotEmpty().When(x => new List<string> { "1", "3", "4", "5", "7", "8", "10" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("FieldIsRequired"));
            RuleFor(x => x.IndependantPhysicalExam).Must(x => new List<string> { "yes", "no", "not_applicable" }.Contains(x)).When(x => new List<string> { "1", "3", "4", "5", "7", "8", "10" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("SelectedValueNotValid"));

            // EmployeeOrCustomer
            RuleFor(x => x.EmployeeOrCustomer).NotEmpty().WithMessage(_localizer.GetLocalizedStringSharedResource("FieldIsRequired"));
            RuleFor(x => x.EmployeeOrCustomer).Must(x => new List<string> { "customer", "employee", "other" }.Contains(x)).WithMessage(_localizer.GetLocalizedStringSharedResource("SelectedValueNotValid"));

            // AgainstOrganizations
            RuleFor(x => x.AgainstOrganizations).NotEmpty().When(x => new List<string> { "1", "3", "4", "5", "7", "8", "10" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("FieldIsRequired"));
            RuleFor(x => x.AgainstOrganizations).Must(x => new List<string> { "yes", "no" }.Contains(x)).When(x => new List<string> { "1", "3", "4", "5", "7", "8", "10" }.Contains(x.ProvinceIncidence)).WithMessage(_localizer.GetLocalizedStringSharedResource("SelectedValueNotValid"));

            // Question3Answers
            RuleForEach(x => x.Question3Answers).Must(x => new List<string> { "charity_non_profit", "condominium_corporation", "federal_government", "first_nation", "individual", "journalism", "political_party" }.Contains(x)).WithMessage(_localizer.GetLocalizedStringSharedResource("SelectedValueNotValid"));

        }
    }
}