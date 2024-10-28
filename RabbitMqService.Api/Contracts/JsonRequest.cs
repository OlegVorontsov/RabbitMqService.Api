
namespace RabbitMqService.Api.Contracts
{
    public record JsonRequest
    (
        RequestJson Request,
        DebitPartJson DebitPart,
        CreditPartJson CreditPart,
        string Details,
        string BankingDate,
        List<Attribute> Attributes
    );
    public record RequestJson
    (
        long Id,
        DocumentJson Document
    );

    public record DocumentJson
    (
        long Id,
        string Type
    );

    public record DebitPartJson
    (
        string AgreementNumber,
        string AccountNumber,
        decimal Amount,
        string Currency,
        List<Attribute> Attributes
    );

    public record CreditPartJson
    (
        string AgreementNumber,
        string AccountNumber,
        decimal Amount,
        string Currency,
        List<Attribute> Attributes
    );

    public record Attribute
    (
        string Code,
        string Value
    );
}
