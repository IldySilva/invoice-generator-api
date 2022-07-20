using GenerateInvoiceApi.Repository;
using System.Text;

namespace GenerateInvoiceApi.Utils
{
    public  static class PDFGenerator
    {
        public static string getHTML()
        {

            var products = DataStorage.GetProducts();


            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>LastName</th>
                                        <th>Age</th>
                                        <th>Gender</th>
                                    </tr>");
            foreach (var emp in products)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", emp.Name, emp.Price, emp.PriceTotal, 0);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();

        }


    }


}
