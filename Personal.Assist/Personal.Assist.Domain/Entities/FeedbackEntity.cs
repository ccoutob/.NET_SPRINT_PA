using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Personal.Assist.Feedback.Domain.Entities
{
    [BsonIgnoreExtraElements]
    public class FeedbackEntity
    {
        //[Key] - Utilizado no Entity para indicar o campo chave (Identificador) da base de dados (Tabela)
        [BsonId]
        public ObjectId Id { get; set; }
        public string Nota { get; set; } = string.Empty;
        public string Positivo { get; set; } = string.Empty;
        public string Negativo { get; set; } = string.Empty;
    }
}