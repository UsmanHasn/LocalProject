using Service.Models;

namespace Service.Interface
{
    public interface IPaymentService
    {
        bool InsertIntoPaymentResponse(PaymentdecryptResponseModel paymentdecryptResponse);
        PaymentdecryptResponseModel GetPaymentdecryptResponse(int Id);
    }
}
