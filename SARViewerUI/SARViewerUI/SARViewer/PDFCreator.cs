using PdfRpt.Core.Contracts;
using PdfRpt.FluentInterface;
using System;
using System.Collections.Generic;
using SARViewer.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARViewerUI.SARViewer
{
    public class PDFCreator
    {
        public IPdfReportData CreatePdfReport(List<Student> studentList)
        {
            return new PdfReport().DocumentPreferences(doc =>
            {
                doc.RunDirection(PdfRunDirection.LeftToRight);
                doc.Orientation(PageOrientation.Portrait);
                doc.PageSize(PdfPageSize.A4);
                doc.DocumentMetadata(new DocumentMetadata
                {
                    Author = "Team Platinum",
                    Application = "PdfRpt",
                    Keywords = "List Report",
                    Subject = "Test Report",
                    Title = "Student Directory"
                });
            })
            .DefaultFonts(fonts =>
            {
                fonts.Path(Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\arial.ttf",
                                  Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\verdana.ttf");
            })
            .PagesFooter(footer =>
            {
                footer.DefaultFooter(DateTime.Now.ToString("MM/dd/yyyy"));
            })
            .MainTableTemplate(template =>
            {
                template.BasicTemplate(BasicTemplate.ClassicTemplate);
            })
            .MainTablePreferences(table =>
            {
                table.ColumnsWidthsType(TableColumnWidthType.Relative);
            })
            .MainTableDataSource(dataSource =>
            {
                dataSource.StronglyTypedList(studentList);
            })
            .MainTableSummarySettings(summarySettings =>
            {
                summarySettings.OverallSummarySettings("Summary");
                summarySettings.PreviousPageSummarySettings("Previous Page Summary");
                summarySettings.PageSummarySettings("Page Summary");
            })
            .MainTableColumns(columns =>
            {
                columns.AddColumn(column =>
                {
                    column.PropertyName("rowNo");
                    column.IsRowNumber(true);
                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
                    column.IsVisible(true);
                    column.Order(0);
                    column.Width(1);
                    column.HeaderCell("#");
                });

                columns.AddColumn(column =>
                {
                    column.PropertyName<Student>(x => x.FirstName);
                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
                    column.IsVisible(true);
                    column.Order(1);
                    column.Width(2);
                    column.HeaderCell("First Name");
                });

                columns.AddColumn(column =>
                {
                    column.PropertyName<Student>(x => x.LastName);
                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
                    column.IsVisible(true);
                    column.Order(2);
                    column.Width(3);
                    column.HeaderCell("Last Name");
                });

                columns.AddColumn(column =>
                {
                    column.PropertyName<Student>(x => x.ID);
                    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
                    column.IsVisible(true);
                    column.Order(3);
                    column.Width(3);
                    column.HeaderCell("Student ID");
                });

                //columns.AddColumn(column =>
                //{
                //    column.PropertyName<User>(x => x.Balance);
                //    column.CellsHorizontalAlignment(HorizontalAlignment.Center);
                //    column.IsVisible(true);
                //    column.Order(4);
                //    column.Width(2);
                //    column.HeaderCell("Balance");
                //    column.ColumnItemsTemplate(template =>
                //    {
                //        template.TextBlock();
                //        template.DisplayFormatFormula(obj => obj == null ? string.Empty : string.Format("{0:n0}", obj));
                //    });
                //    column.AggregateFunction(aggregateFunction =>
                //    {
                //        aggregateFunction.NumericAggregateFunction(AggregateFunction.Sum);
                //        aggregateFunction.DisplayFormatFormula(obj => obj == null ? string.Empty : string.Format("{0:n0}", obj));
                //    });
                //});

            })
            .Export(export =>
            {
                export.ToExcel();
                export.ToCsv();
                export.ToXml();
            })
            .Generate(data => data.AsPdfFile(AppPath.ApplicationPath + "\\Resources\\RptIListSample.pdf"));
        }
    }
}
