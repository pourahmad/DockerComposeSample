using MongoDB.Bson;

namespace DockerComposeSampleMongoDb.Services;

public class CategoryDto
{
    public ObjectId _id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
