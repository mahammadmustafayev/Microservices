﻿using MongoDB.Bson.Serialization.Attributes;

namespace Course.Services.Catalog.Models;

public class Course
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string CourseId { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
    public decimal Price { get; set; }
    public string Picture { get; set; }
    public string UserId { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
    public DateTime CreatedTime { get; set; }
    public Feature Feature { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string CategoryId { get; set; }

    [BsonIgnore]
    public Category Category { get; set; }
}
