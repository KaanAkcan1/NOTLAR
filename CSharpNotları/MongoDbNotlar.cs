using MongoDB.Bson;
using MongoDB.Driver; //Manage nuget packagestan yükle

namespace CSharpNotları
{
    public class MongoDbNotlar
    {
        //use sample_training şeklinde database seçiyoruz
        // db.listingAndReviews.findOne();
        // win + shift + s ile ekran görüntüsü almak daha kolay


        #region MongoBasic

        #region büyük küçük
        //db.routes.find({ "stops": { "$gt": 0 }}).pretty()
        //gte
        //lt
        //lte
        //db.trips.find({ "tripduration": { "$lte" : 70 },
        //        "usertype": { "$ne": "Subscriber" } }).pretty()

        #endregion

        #region and or
        //db.routes.find({ "$and": [ { "$or" :[ { "dst_airport": "KZN" },
        //                            { "src_airport": "KZN" }
        //                          ] },
        //                  {
        //"$or" :[ { "airplane": "CR2" },
        //                             { "airplane": "A81" } ] }
        //                 ]}).pretty()
        //nor 
        //        not
        //      db.inspections.find(
        //{ "$or": [ { "date": "Feb 20 2015" },
        //           { "date": "Feb 21 2015" } ],
        //  "sector": { "$ne": "Cigarette Retail Dealer - 127" }}).pretty()

        #endregion

        #region expr
        //        db.trips.find({ "$expr": { "$eq": [ "$end station id", "$start station id"]
        //    }
        //}).count()
        //     
        //db.trips.find({
        //    "$expr": {
        //        "$and": [ { "$gt": [ "$tripduration", 1200 ]},
        //                  { "$eq": [ "$end station id", "$start station id" ]}
        //                ]}
        //}).count()
        #endregion

        #region array
        //        db.listingsAndReviews.find({ "amenities": {
        //                                                      "$size": 20,
        //                                                      "$all": [ "Internet", "Wifi",  "Kitchen",
        //                                                              "Heating", "Family/kid friendly",
        //                                                              "Washer", "Dryer", "Essentials",
        //                                                              "Shampoo", "Hangers",
        //                                                              "Hair dryer", "Iron",
        //                                                              "Laptop friendly workspace" ]
        //                                                  }
        //                                  }).pretty()


        //db.listingsAndReviews.find({ "reviews": { "$size":50 },
        //                     "accommodates": { "$gt":6 }})


        //db.listingsAndReviews.find({ "property_type": "House",
        //                     "amenities": "Changing table" }).count()

        #endregion

        #region array and display kısıtlma
        //Find all documents with exactly 20 amenities which include all the amenities listed in the query array, and display their price and address:
        //db.listingsAndReviews.find({
        //            "amenities":
        //        {
        //                "$size": 20, "$all": [ "Internet", "Wifi",  "Kitchen", "Heating",
        //                                 "Family/kid friendly", "Washer", "Dryer",
        //                                 "Essentials", "Shampoo", "Hangers",
        //                                 "Hair dryer", "Iron",
        //                                 "Laptop friendly workspace" ] }
        //        },
        //                            {"price": 1, "address": 1}).pretty()


        //Find all documents that have Wifi as one of the amenities only include price and address in the resulting cursor:
        //db.listingsAndReviews.find({ "amenities": "Wifi" },
        //                           { "price": 1, "address": 1, "_id": 0 }).pretty()


        //Find all documents that have Wifi as one of the amenities only include price and address in the resulting cursor, also exclude ``"maximum_nights"``. **This will be an error:*
        //db.listingsAndReviews.find({ "amenities": "Wifi" },
        //                           { "price": 1, "address": 1,
        //                             "_id": 0, "maximum_nights":0 }).pretty()



        //Switch to this database:
        //use sample_training
        //Get one document from the collection:
        //db.grades.findOne()


        //Find all documents where the student in class 431 received a grade higher than 85 for any type of assignment:
        //db.grades.find({ "class_id": 431 },
        //               { "scores": { "$elemMatch": { "score": { "$gt": 85 } } }
        //             }).pretty()



        //Find all documents where the student had an extra credit score:
        //db.grades.find({
        //            "scores": { "$elemMatch": { "type": "extra credit" } }
        //        }).pretty()

        #endregion

        #region findOne ve find
        //        db.trips.findOne({ "start station location.type": "Point" })

        //db.companies.find({ "relationships.0.person.last_name": "Zuckerberg" },
        //                  { "name": 1 }).pretty()

        //db.companies.find({
        //    "relationships.0.person.first_name": "Mark",
        //                    "relationships.0.title": { "$regex": "CEO" }
        //},
        //                  { "name": 1 }).count()


        //db.companies.find({
        //    "relationships.0.person.first_name": "Mark",
        //                    "relationships.0.title": { "$regex": "CEO" }
        //},
        //                  { "name": 1 }).pretty()

        //db.companies.find({
        //    "relationships":
        //                      {
        //        "$elemMatch": {
        //            "is_past": true,
        //                                        "person.first_name": "Mark" }
        //    }
        //},
        //                  { "name": 1 }).pretty()

        //db.companies.find({
        //    "relationships":
        //                      {
        //        "$elemMatch": {
        //            "is_past": true,
        //                                        "person.first_name": "Mark" }
        //    }
        //},
        //                  { "name": 1 }).count()
        #endregion

        #region aggregate
        //Find all documents that have Wifi as one of the amenities.Only include price and address in the resulting cursor.
        //    db.listingsAndReviews.find({ "amenities": "Wifi" },
        //                   { "price": 1, "address": 1, "_id": 0 }).pretty()


        //Using the aggregation framework find all documents that have Wifi as one of the amenities``*. Only include* ``price and address in the resulting cursor.
        //    db.listingsAndReviews.aggregate([
        //                          { "$match": { "amenities": "Wifi" } },
        //                          { "$project": { "price": 1,
        //                                          "address": 1,
        //                                          "_id": 0 }}]).pretty()


        //Find one document in the collection and only include the address field in the resulting cursor.
        //db.listingsAndReviews.findOne({ },{ "address": 1, "_id": 0 })


        //Project only the address field value for each document, then group all documents into one document per address.country value.
        //db.listingsAndReviews.aggregate([{ "$project": { "address": 1, "_id": 0 } },
        //                                  { "$group": { "_id": "$address.country" }}])


        //Project only the address field value for each document, then group all documents into one document per address.country value, and count one for each document in each group.
        //db.listingsAndReviews.aggregate([
        //                                  { "$project": { "address": 1, "_id": 0 } },
        //                          { "$group": { "_id": "$address.country",
        //                                        "count": { "$sum": 1 } } }
        //                        ])        


        //Find all documents that have Wifi as one of the amenities.Only include price and address in the resulting cursor.
        //    db.listingsAndReviews.find({ "amenities": "Wifi" },
        //                   { "price": 1, "address": 1, "_id": 0 }).pretty()


        //Using the aggregation framework find all documents that have Wifi as one of the amenities``*. Only include* ``price and address in the resulting cursor.
        //    db.listingsAndReviews.aggregate([
        //                          { "$match": { "amenities": "Wifi" } },
        //                          { "$project": { "price": 1,
        //                                          "address": 1,
        //                                          "_id": 0 }}]).pretty()


        //Find one document in the collection and only include the address field in the resulting cursor.
        //db.listingsAndReviews.findOne({ },{ "address": 1, "_id": 0 })


        //Project only the address field value for each document, then group all documents into one document per address.country value.
        //db.listingsAndReviews.aggregate([{ "$project": { "address": 1, "_id": 0 } },
        //                                  { "$group": { "_id": "$address.country" }}])


        //Project only the address field value for each document, then group all documents into one document per address.country value, and count one for each document in each group.
        //db.listingsAndReviews.aggregate([
        //                                  { "$project": { "address": 1, "_id": 0 } },
        //                          { "$group": { "_id": "$address.country",
        //                                        "count": { "$sum": 1 } } }
        //                        ])
        #endregion

        #region sort and limit

        //db.zips.find().sort({ "pop": 1 }).limit(1)

        //db.zips.find({ "pop": 0 }).count()

        //db.zips.find().sort({ "pop": -1 }).limit(1)

        //db.zips.find().sort({ "pop": -1 }).limit(10)

        //db.zips.find().sort({ "pop": 1, "city": -1 })

        //db.zips.find({"birth year" : {$ne :""}},{"birth year" : 1}).sort({ "birth year": -1})

        #endregion

        #region index
        //Sorgu analizi sonrası sorgularda bir yavaşlama var ise en çok kullanılan alana index eklenebilir.

        //Koleksiyondaki alana index özelliği eklemek için ensureIndex metodu kullanılır.
        //db.kisiler.ensureIndex({ adi: 1 });

        //Koleksiyondaki index özelliğine sahip alanlar listelemek için getIndexes metodu kullanılır.
        //db.kisiler.getIndexes();

        //Koleksiyondaki indexleri kaldırmak için dropIndex metodu kullanılır.
        //db.kisiler.dropIndex({ adi: 1 });

        //db.trips.createIndex({ "birth year": 1 })

        //db.trips.createIndex({ "start station id": 1, "birth year": 1 })

        #endregion

        #region upsert
        //        db.iot.updateOne({ "sensor": r.sensor, "date": r.date,
        //                   "valcount": { "$lt": 48 } },
        //                         { "$push": { "readings": { "v": r.value, "t": r.time
        //} },
        //                        "$inc": { "valcount": 1, "total": r.value } },
        //                 { "upsert": true })
        #endregion

        #endregion


        #region MongoDotNet

        #region Using driver
        //Create a client that points to your data store
        var some_uri_to_MongoDb = MongoClientSettings.FromConnectionString("mongodb+srv://kaan:111222333@mflix.ulybz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
        //some_uri_to_MongoDb was shown in Connect>ChooseaConnectionMethod
        var client = new MongoClient(some_uri_to_MongoDb);



        //Sepecify the database and collection u want to use
        var db = client.GetDatabase("sample_mflix");//database name
        var collection = db.GetCollection<BsonDocument>("movies");//collection name

        //using example
        var result = collection
            .Find(new BsonDocument("title", "The Princess Bride"))
            .FirstOrDefault();

        #endregion


        #region Filter methods
        var guitarsCollection = db.GetCollection<BsonDocument>("guitars");

        var filter = "{price : {$gt : 400}}";
        filter = "{ $and: [ { price : { $gt : 400}}, { price : { $lt : 600 } ] }";
        var expensiveGuitars = guitarsCollection.Find(filter);
        //or


        var filter = new BsonDocument("price", new BsonDocument("$gt", 400));
        filter = BsonDocument( "$and", new BsonArray
            {
            new BsonDocument( "price", new BsonDocument( "$gt", 400 ) ),
            new BsonDocument( "price", new BsonDocument( "$lt", 600 ) ),
            });

        var expensiveGuitars = guitarsCollection.Find(filter);


    var builder = Builders<BsonDocument>.Filter;
    var filter = builder.Gt("price", 400) & builder.Lt("price", 600);
    var midGrandeGuitars = guitarsCollection.Find(filter);

    var expensiveGuitars = guitarsCollection
    .Find(global => global.Price > 400)
    .ToList();
    #endregion


    #region Create Update Delete
    //asdasd
    //var newGuitar = new Guitar{
    //        Id = 1234;
    //        Make= Ginson;
    //        Model"Les Paul"
    //        Price("675.00")
    //         };
    //guitarsCollection.InsertOne(new Guitar);


    //var filter = new BsonDocument("Id", 1234);
    //var update = new BsonDocument("$set", new BsonDocument("price", 700));
    //var options = new UpdateOptions { IsUpsert = true };
    //var result = guitarsCollection.UpdateOne(filter, update, options);

    //var f = Builders<Guitar>.Filter.Eq(g => g.Id, 1234);
    //var b = Builders<Guitar>.Update.Set(g => g.Price, 700);
    //guitarsCollection.UpdateOne(f, b);

    //guitarsCollection.DeleteOne(global => global.ID == 1234);
    //_theatersCollection.FindOneAndDeleteAsync(filter);
    //await _theatersCollection.DeleteOneAsync(filter);
    //var result = await _theatersCollection.DeleteManyAsync(filter);
    //Assert.AreEqual(3, result.DeletedCount)


    #endregion


    #region Basic Reads
    var filter = new BsonDocument("title", "The Princess Bride");

    var betterFilter = Builders<Movie>.Filter.Eq(m => m.Title, "The Princess Bride");

    var projectionFilter = Builders<Movie>.Projection
        .Include(m => m.Title)
        .Include(m => m.Year)
        .Include(m => m.Cast)
        .Exlude(m => m.Id);

    var movieProjected = await _moviesCollection
        .Find<Movie>(betterFilter)
        .Project<Movie>(projectionFilter)
        .FirstOrDefaultAsync();


    #endregion


    #region Advanced Read

    var movies = await _moviesCollection.Find<Movie>(filter)
        .Limit(5)
        .ToListAsync();

    var movies = await _moviesCollection.Find<Movie>(Builders<Movie>.Filter.Empty)
        .Sort(new BsonDocument("year", 1))
        .Limit(4)
        .Skip(12)
        .ToListAsync();


    return await _moviesCollection
                          .Find(m => m.Countries.Any(c => countries.Contains(c)))
                          .SortByDescending(m => m.Title)
                          .Project<MovieByCountryProjection>(Builders<Movie>
                                                                            .Projection
                                                                                .Include(x => x.Title)
                                                                                .Include(x => x.Id))
                          .ToListAsync(cancellationToken);


     return await _moviesCollection
                .Find(Builders<Movie>.Filter.In("genres", genres))
                .Limit(limit)
                .Skip(page* limit)
                .Sort(sort)
                .ToListAsync(cancellationToken);

    #endregion


    #region Basic Aggretions
    //$match
    //{
    //directors : "Sam Raimi"
    //}

    //$project
    //{
    //_id: 0,
    // title: 1,
    // "imdb.rating":1
    //}

    // $group
    //{
    //_id: 0,
    //  avg_rating:
    //    {
    //        "$avg": "$imdb.rating"
    //  }
    //}

    #endregion


    #region Using Aggregation Builders
    //var matchStage = new BsonDocument("$match",
    //    new BsonDocument("directors", "Bob Reiner"));

    //var sortStage = new BsonDocument("$sort",
    //    new BsonDocument("tomatoes.viewer.numReviews", -1));

    //var projectionStage = new BsonDocument("$project",
    //    new BsonDocument
    //    {
    //        {"_id", 0 },
    //        {"Movie Title", "$title" },
    //        {"Year", "$year" },
    //        {"Avarage User Rating", "$tomatoes.viewer.raitng" }
    //    });

    //var pipeline = PipelineDefinition<Movie, BsonDocument>
    //    .Create(new BsonDocument[]){
    //    matchStage,
    //    sortStage,
    //    projectionStage
    //    });

    //var result = _moviesCollection.Aggregate(pipeline).ToList();

    //another Example
    // I match movies by cast members
    var matchStage = new BsonDocument("$match",
        new BsonDocument("cast",
            new BsonDocument("$in",
                new BsonArray { cast })));

    //I limit the number of results
    var limitStage = new BsonDocument("$limit", DefaultMoviesPerPage);

    //I sort the results by the number of reviewers, descending
    var sortStage = new BsonDocument("$sort",
        new BsonDocument("tomatoes.viewer.numReviews", -1));

    // In conjunction with limitStage, I enable pagination
    var skipStage = new BsonDocument("$skip", DefaultMoviesPerPage * page);

    // I build the facets
    var facetStage = BuildFacetStage();

    // I am the pipeline that runs all of the stages
    var pipeline = new[]
    {
                    matchStage,
                    sortStage,
                    skipStage,
                    limitStage,
                    facetStage
                    // add the remaining stages in the correct order
    };

    #endregion


    #region Basic Write-Insert
    //await _theatersCollection.InsertOneAsync(newTheater); //

    //await _theatersCollection.InsertManyAsync(
    //    new List<Theater>()
    //    {
    //        theater1,theater2,theater3
    //}); 

    #endregion


    #region Update Data
    //_theatersCollection.UpdateOneAsync();//return an UpdateResult object
    //_theatersCollection.UpdateManyAsync();//return an UpdateResult object
    //_theatersCollection.FindOneAndUpdateAsync();//updates a single document and returns the updated document

    //var filter = Builders<Theater>.Filter.Eq(t => t.Theater.Id, 8);
    //var theater = await _theaterCollection.Find<Theater>(filter).FirstOrDefaultAsync();
    //Assert.AreEqual("14141 Aldrich Ave S", theater.Location.Adress.Street1);

    //var updateResult = _theatersCollection.UpdateOne(filter,
    //    new BsonDocument("$set",
    //        new BsonDocument("location.address.street1", "123 Main St."))
    //    );

    //_theatersCollection.UpdateOne(FilterDefinition,
    //    Builders<Theater>.Update.Set(t => t.Location.Adress.Street1,
    //    "123 Main St")
    //    );



    //Soru cevabı =>
    //     public async Task<User> GetUserAsync(string email,
    //CancellationToken cancellationToken = default)
    // {
    //     return await _usersCollection.Find(new BsonDocument("email", email))
    //        .FirstOrDefaultAsync(cancellationToken);
    // }

    // public async Task<UserResponse> AddUserAsync(string name, string email,
    //    string password, CancellationToken cancellationToken = default)
    // {
    //     try
    //     {
    //         var user = new User
    //         {
    //             Name = name,
    //             Email = email,
    //             HashedPassword = PasswordHashOMatic.Hash(password)
    //         };

    //         await _usersCollection
    //            .InsertOneAsync(user, cancellationToken: cancellationToken);

    //         var newUser = await GetUserAsync(user.Email, cancellationToken);
    //         return new UserResponse(newUser);
    //     }
    //     catch (Exception ex)
    //     {
    //         return ex.Message.StartsWith("MongoError: E11000 duplicate key error")
    //            ? new UserResponse(false, "A user with the given email already exists.")
    //            : new UserResponse(false, ex.Message);
    //     }
    // }

    // public async Task<UserResponse> LoginUserAsync(User user,
    //    CancellationToken cancellationToken = default)
    // {
    //     try
    //     {
    //         var storedUser = await GetUserAsync(user.Email, cancellationToken);
    //         if (storedUser == null)
    //             return new UserResponse(false, "No user found. Please check the email address.");

    //         if (user.HashedPassword != null && user.HashedPassword != storedUser.HashedPassword)
    //         {
    //             return new UserResponse(false, "The hashed password provided is not valid");
    //         }

    //         if (user.HashedPassword == null && !PasswordHashOMatic.Verify(user.Password, storedUser.HashedPassword))
    //         {
    //             return new UserResponse(false, "The password provided is not valid");
    //         }

    //         await _sessionsCollection.UpdateOneAsync(
    //                 new BsonDocument("user_id", user.Email),
    //                 Builders<Session>.Update.Set(s => s.UserId, user.Email).Set(s => s.Jwt, user.AuthToken),
    //                 new UpdateOptions { IsUpsert = true },
    //                 cancellationToken);

    //         storedUser.AuthToken = user.AuthToken;
    //         return new UserResponse(storedUser);
    //     }
    //     catch (Exception ex)
    //     {
    //         return new UserResponse(false, ex.Message);
    //     }
    // }

    // public async Task<UserResponse> LogoutUserAsync(string email,
    //    CancellationToken cancellationToken = default)
    // {

    //     await _sessionsCollection.DeleteOneAsync(new BsonDocument("user_id", email),
    //        cancellationToken);
    //     return new UserResponse(true, "User logged out.");
    // }

    // public async Task<Session> GetUserSessionAsync(string email,
    //    CancellationToken cancellationToken = default)
    // {
    //     return await _sessionsCollection.Find(new BsonDocument("user_id", email))
    //        .FirstOrDefaultAsync(cancellationToken);


    //     await _usersCollection
    //.WithWriteConcern(WriteConcern.WMajority)
    //.InsertOneAsync(user, cancellationToken: cancellationToken);

    #endregion

    #region BasicJoin
    //  {
    //  from: 'comments', commentsin içindeki
    //  let: {'id': '$_id'},
    //  pipeline:[ { '$match' :{ '$expr' : { '$eq' : ['$movie_id', '$$id']  } } } ],   movie_id ile id değerini maçlayip bişiler bişiler
    //  as: 'movie_comments'
    //}
    #endregion


    #region Look Up
    var filter = new BsonDocument[]
    {
        new BsonDocument("$match",
            new BsonDocument("year",
                new BsonDocument
                {
                    {"gte", 1980},
                    {"lt", 1990 }
                })),
        new BsonDocument("$lookup",
            new BsonDocument
            {
                {"from", "comments"},
                {"let", new BsonDocument("id", "$_id") },
                {"pipeline",
                    new BsonArray
                    {
                        new BsonDocument("$match",
                            new BsonDocument("expr",
                                new BsonDocument("$eq",
                                    new BsonArray
                                    {
                                        "$movie_id",
                                        "$$id"
                                    }))),
                        new BsonDocument("$count", "count")
                    } },
                {"as", "movie_comments" }
            })
    };

    var pipeline = PipelineDefinition<Movie, BsonDocument>
        .Create(filter);
    var movies = _moviesCollection.Aggregate(pipeline).ToList();



    //2.Yol

    var movies = _moviesCollection//c commentcollectiondan geliyor.m önceki yerden taşınabiliyor.
        .Aggregate()
        .Match(m => (int)m.Year < 1990 && (int)m.Year >= 1980)
        .Lookup(
            _commentsCollection, //Verinin alınacağı collection
            m => m.Id,//Şu anki property id
            c => c.MovieId, //Comment collectiondaki movie ıd
            (Movie m) => m.Comments// dönüş tipi ve ismi
            )
        .ToList();



    #endregion
    #region LookUp Uygulama
    public async Task<Movie> AddCommentAsync(User user, ObjectId movieId, string comment,
   CancellationToken cancellationToken = default)
    {
        try
        {
            var newComment = new Comment
            {
                Date = DateTime.UtcNow,
                Text = comment,
                Name = user.Name,
                Email = user.Email,
                MovieId = movieId
            };

            await _commentsCollection.InsertOneAsync(
               newComment,
               new InsertOneOptions(),
               cancellationToken);

            return await _moviesRepository.GetMovieAsync(movieId.ToString(), cancellationToken);
        }
        catch
        {
            return null;
        }
    }

    public async Task<UpdateResult> UpdateCommentAsync(User user,
       ObjectId movieId, ObjectId commentId, string comment,
       CancellationToken cancellationToken = default)
    {
        return await _commentsCollection.UpdateOneAsync(
                  Builders<Comment>.Filter.Where(c => c.Id == commentId && c.Email == user.Email),
                  Builders<Comment>.Update.Set(c => c.Text, comment).Set(c => c.Date, DateTime.UtcNow),
                  new UpdateOptions { IsUpsert = false },
                  cancellationToken);
    }
    #endregion

    #endregion


}
}
