using Service.Models;

namespace Service.Interface
{
    public interface IPaymentService
    {
        bool InsertIntoPaymentResponse(PaymentdecryptResponseModel paymentdecryptResponse);
        bool InsertPaymentRequest(PaymentPayLoad PaymentPayLoad);
        PaymentdecryptResponseModel GetPaymentdecryptResponse(int Id);
    }
}
