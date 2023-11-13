using Service.Models;

namespace Service.Interface
{
    public interface IPaymentService
    {
        bool InsertIntoPaymentResponse(PaymentdecryptResponseModel paymentdecryptResponse);
        bool InsertPaymentRequest(PaymentPayLoad PaymentPayLoad);
        PaginatedTransactionModel GetPaymentResponse(int pageSize, int pageNumber, string? SearchText);
        PaymentPayLoad GetPaymentRequestDetail(string requestId);
    }
}
