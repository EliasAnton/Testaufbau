using ProtoBuf;

namespace Testaufbau.DataAccess.Models;

[ProtoContract]
public enum ArticleCategory
{
    Clothing = 1,
    Footware = 2,
    Electronics = 3,
    Household = 4
}