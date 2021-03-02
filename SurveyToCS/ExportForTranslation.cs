using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SurveyToCS
{
	public class ExportForTranslation
	{
		public static string CreateCSV(SurveyObject survey)
		{
			StringBuilder builder = new StringBuilder();
			List<TranslationItemCSV> list = new List<TranslationItemCSV>();

			//	page_name, element_name (or value), panel (null), property_name, en, fr
			//

			foreach (var page in survey.pages)
			{
				if (page.title != null)
				{
					list.Add(new TranslationItemCSV(page.name, page.name, "title", page.title));
				}

				GetElementTranslation(list, page, page.elements);
			}

			foreach(var item in list)
			{
				builder.AppendLine(item.ToString());
			}

			return builder.ToString();
		}

		public static string ReBuildJSON(string csvStr, string pathToJSONFile)
		{
			string json = string.Empty;

			// pathToJSONFile = @"C:\Users\jbrouillette\source\repos\online-complaint-form-pa_jf\ComplaintFormCore\wwwroot\sample-data\survey_pbr.json";
			SurveyObject survey;

			//string jsonString = File.ReadAllText(pathToJSONFile);

			// Convert the JSON string to a JObject:
			//JObject jObject = JsonConvert.DeserializeObject(jsonString) as JObject;

			// Select a nested property using a single string:

			//JToken jToken = jObject.SelectToken("Pages").Where(p > pathToJSONFile.).SelectToken("title");
			//JToken jToken = jObject.SelectToken("Pages[?(@.name == 'page_breach_description_affected')].title[0].fr");

			// Update the value of the property:
			//jToken.Replace("myNewPassword123");

			// Convert the JObject back to a string:
			//string updatedJsonString = jObject.ToString();
			//	File.WriteAllText(pathToJSONFile, updatedJsonString);

			try
			{
				// read file into a string and deserialize JSON to a type
				survey = JsonConvert.DeserializeObject<SurveyObject>(File.ReadAllText(pathToJSONFile));
			}
			catch
			{
				Console.WriteLine("Cannot find the file " + pathToJSONFile);
				return "";
			}

			var test = survey.pages.Where(p => p.name == "page_step_2_1_q_2_1_6").First().elements.Where(e => e.name == "pnd_OtherInstitutionHead").First();

			if(test.type == "paneldynamic")
			{
				foreach(var item in test.templateElements)
				{
					item.title.fr = "xyz";
				}
			}
			else if(test.type == "matrixdynamic")
			{

			}

			//test.fr = "salut ca va";

			//string output = JsonConvert.SerializeObject(survey, Formatting.Indented);
			//string finaloutput = JToken.FromObject(survey).ToString();
			//string prettyJson = JToken.Parse(output).ToString(Formatting.Indented);
			//string jsonFormatted = jkho.Parse(output).ToString(Formatting.Indented);

			var options = new System.Text.Json.JsonSerializerOptions
			{
				IgnoreNullValues = true,
				WriteIndented = true,
				Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
			};

			string jsonString = System.Text.Json.JsonSerializer.Serialize(survey, options);
			return jsonString;
		}

		private static void GetElementTranslation(List<TranslationItemCSV> list, Page page, List<Element> elements)
		{
			foreach (var element in elements)
			{
				string elementName = !string.IsNullOrWhiteSpace(element.valueName) ? element.valueName : element.name;

				if (element.type == "panel")
				{
					if (element.title != null)
					{
						list.Add(new TranslationItemCSV(page.name, elementName, "title", element.title));
					}

					GetElementTranslation(list, page, element.elements);
				}
				else
				{
					if (element.title != null)
					{
						list.Add(new TranslationItemCSV(page.name, elementName, "title", element.title));
					}

					if (element.description != null)
					{
						list.Add(new TranslationItemCSV(page.name, elementName, "description", element.description));
					}

					if(element.type == "html" && element.html != null)
					{
						list.Add(new TranslationItemCSV(page.name, elementName, "html", element.html));
					}

					if (element.choices != null)
					{
						foreach(var choice in element.choices)
						{
							list.Add(new TranslationItemCSV(page.name, elementName, "choice", choice.text));
						}
					}

					if (element.type == "matrixdynamic")
					{
						if (element.addRowText != null)
						{
							list.Add(new TranslationItemCSV(page.name, elementName, "addRowText", element.addRowText));
						}

						if (element.removeRowText != null)
						{
							list.Add(new TranslationItemCSV(page.name, elementName, "removeRowText", element.removeRowText));
						}

						if (element.confirmDeleteText != null)
						{
							list.Add(new TranslationItemCSV(page.name, elementName, "confirmDeleteText", element.confirmDeleteText));
						}

						if (element.panelAddText != null)
						{
							list.Add(new TranslationItemCSV(page.name, elementName, "panelAddText", element.panelAddText));
						}

						if (element.columns != null && element.columns.Count > 0)
						{
							foreach(var column in element.columns)
							{
								if (column.title != null)
								{
									list.Add(new TranslationItemCSV(page.name, elementName, "column-title", column.title));
								}
							}
						}
					}

					if(element.type == "paneldynamic")
					{

					}
				}
			}
		}
	}

	public class TranslationItemCSV
	{
		public TranslationItemCSV(string pageName, string elementName, string propertyName, Traduction traductionElement)
		{
			PageName = pageName;
			ElementName = elementName;
			PropertyName = propertyName;
			En = traductionElement.en;
			Fr = traductionElement.fr;
		}

		public string PageName { get; set; }

		public string ElementName { get; set; }

		public string PropertyName { get; set; }

		public string En { get; set; }

		public string Fr { get; set; }

		public override string ToString()
		{
			return $"{string.Format("\"{0}\"", PageName)},{string.Format("\"{0}\"", ElementName)},{string.Format("\"{0}\"", PropertyName)},{string.Format("\"{0}\"", En)},{string.Format("\"{0}\"", Fr)}";
		}
	}
}