using System;
using System.IO;

namespace ConfigAplicator
{
    class Program
    {
        static void Main(string[] args)
        {

            string dirAppsettings = @"C:\Users\rpfilho\Desktop\appsettings\appsettings.json";
            string[] robots =
            {
                "FlowConsumerSchedule",
                "CallbackBiometricAnalysis",
                "CallBackDigitalWalletPaymentStatus",
                "CallbackPayment",
                "CallbackPaymentRefundStatus",
                "CallBackPixPaymentStatus",
                "CallBackTransferPaymentStatus",
                "CallPendingCreditOrdersGDS",
                "CallPendingCreditOrdersSabre",
                "CancelAllInsurances",
                "CancelAllPayments",
                "CancelAllRiskAnalysis",
                "CancelAutomaticCancellationOrders",
                "CancelInactiveBilledOrders",
                "CancellationEmailDispatcher",
                "CancelPendingSeats",
                "CancelSameDayOrders",
                "ChangeEmailServiceById",
                "ChargePOS",
                "IssueInsurance",
                "ManualReviewCallback",
                "NewCancelOrder",
                "PaymentProcessNotification",
                "PendingCreditOrdersAmadeus",
                "PointsRedeem",
                "ReaccommodationProcessQueue",
                "ReaccomodationEmailQueueWithAccepted",
                "ReaccomodationEmailWithoutAccepted",
                "ReacRecoverPnrsGolGws",
                "RiskAnalysisService",
                "SendReceiptQueue",
                "SyncSaleRisk",
                "UpdateRefundResult",
                "VirtualCardEligibility",
                "FlowConsumerSchedule"
            };
            Console.WriteLine("Qual ambiente?");
            string ambiente = Console.ReadLine();

            foreach (var robot in robots)
            {
                Console.WriteLine($"█████████████████████████████████      {robot}      █████████████████████████████████");

                string serviceName = robot;
                switch (robot)
                {
                    case "CallbackPayment" :
                        serviceName = "CallbackPaymentStatus";
                        break;

                    case "ReaccomodationEmailQueueWithAccepted":
                        serviceName = "SendReaccomodationEmailWithAcceptedById";
                        break;

                    case "ReaccomodationEmailWithoutAccepted":
                        serviceName = "SendReaccomodationEmailWithoutAcceptedById";
                        break;

                    case "ChangeEmailServiceById":
                        serviceName = "SendChangeConfirmationEmailServiceById";
                        break;

                    case "SendReceiptQueue":
                        serviceName = "SendReceiptEmail";
                        break;

                    case "CancelAllRiskAnalysis":
                        serviceName = "CancelAllRiskAnalysis";
                        break;

                    case "CallPendingCreditOrdersSabre":
                        serviceName = "CallPendingCreditOrdersSabreService";
                        break;

                    case "CallPendingCreditOrdersGDS":
                        serviceName = "CallPendingCreditOrdersGDSService";
                        break;

                    case "PendingCreditOrdersAmadeus":
                        serviceName = "PendingCreditOrdersAmadeusService";
                        break;

                    case "ReacRecoverPnrsGolGws":
                        serviceName = "ReaccommodationRecoverPnrsGolGwsService";
                        break;

                    case "ReaccommodationProcessQueue":
                        serviceName = "ReaccommodationProcessQueueService";
                        break;
                }
                string p1 = "{ \"ServiceName\": ";
                string p2 = "\"" + serviceName + "\", ";
                string p3 = "\"ConnectionStrings\": { \"Framework\": ";
                string connString = "\"Data Source=VN-HOMOLOG;Initial Catalog=" +ambiente+ "_Framework;Persist Security Info=True;Integrated Security=true\"";
                string p4 = connString + "},";
                string p5 = "\"Logging\": { \"LogLevel\": { \"Default\": \"Information\", \"Microsoft\": \"Warning\", \"Microsoft.Hosting.Lifetime\": \"Information\" }}}";
                string appsettings = p1 + p2 + p3 + p4 + p5;
  

                var file = File.CreateText(dirAppsettings);
                file.WriteLine(appsettings);
                file.Close();

                string targetPath = @"\\" + ambiente + @"\c$\inetpub\Win.Services\ROBOTS\" + robot;
                Console.WriteLine(targetPath);
                
                string sourceFile = System.IO.Path.Combine(dirAppsettings);
                string destFile = System.IO.Path.Combine(targetPath, "appsettings.json");

                System.IO.File.Copy(sourceFile, destFile, true);

                
            }
            Console.Clear();
            Console.WriteLine("Fim");
            Console.ReadKey();
         

        }
    }
}
