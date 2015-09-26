using System.Windows;

namespace Omega
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {

        }

        private void AccountBalanceTest()
        {
            Model.InternalAccount IA = new Model.InternalAccount(0, "Hello Eve");

            System.Diagnostics.Debug.WriteLine("\n");
            System.Diagnostics.Debug.WriteLine(IA.Balance + "\n");

            IA.CreateTransaction(10.50m, null, "Test Transaction 0     ", null, System.DateTime.Now, Model.Enum.TransactionType.Credit);
            IA.CreateTransaction(10.50m, null, "Test Transaction 1     ", null, System.DateTime.Now, Model.Enum.TransactionType.Credit);

            //Should be 0
            System.Diagnostics.Debug.WriteLine(IA.Balance + "\n");

            IA.Evaluate();

            // Should be 21
            System.Diagnostics.Debug.WriteLine(IA.Balance + "\n");
            
            IA.CreateTransaction(10.50m, null, "Test Transaction 2     ", null, System.DateTime.Now, Model.Enum.TransactionType.Credit);

            IA.Evaluate();

            // Should be 31.50
            System.Diagnostics.Debug.WriteLine(IA.Balance + "\n");

            IA.CreateTransaction(10.50m, null, "Test Transaction 3     ", null, System.DateTime.Now, Model.Enum.TransactionType.Credit);

            IA.Evaluate();

            // Should be 42
            System.Diagnostics.Debug.WriteLine(IA.Balance + "\n");

            IA.CreateRunningTransaction(5.50m, null, System.DateTime.Now.Add(System.TimeSpan.FromSeconds(30)), System.TimeSpan.FromSeconds(10), "Test RunningTransaction", null, System.DateTime.Now,
                                        Model.Enum.TransactionType.Debit);
                        
            //Sleep time in ms to allow future transactions testing
            System.Threading.Thread.Sleep(15000);

            IA.Evaluate();

            // Should be 31
            System.Diagnostics.Debug.WriteLine(IA.Balance + "\n");

            //Sleep time in ms to allow future transactions testing
            System.Threading.Thread.Sleep(15000);

            IA.Evaluate();

            // Should be 20
            System.Diagnostics.Debug.WriteLine(IA.Balance + "\n");


            // Print Acount Transactions        
            foreach (Model.AccountTransaction AT in IA.Transactions)
            {
                System.Diagnostics.Debug.WriteLine(AT.Name + " " + AT.Amount + " \t" + AT.Type + " \t" + AT.ReviewDate + " " + AT.State);
            }
        }
    }
}
