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
        //    var guitarsCollection = db.GetCollection<BsonDocument>("guitars");

        //    var filter = "{price : {$gt : 400}}";
        //    filter = "{ $and: [ { price : { $gt : 400}}, { price : { $lt : 600 } ] }";
        //    var expensiveGuitars = guitarsCollection.Find(filter);
        //    //or


        //    var filter = new BsonDocument("price", new BsonDocument("$gt", 400));
        //    filter = BsonDocument( "$and", new BsonArray
        //        {
        //        new BsonDocument( "price", new BsonDocument( "$gt", 400 ) ),
        //        new BsonDocument( "price", new BsonDocument( "$lt", 600 ) ),
        //        });

        //    var expensiveGuitars = guitarsCollection.Find(filter);


        //var builder = Builders<BsonDocument>.Filter;
        //var filter = builder.Gt("price", 400) & builder.Lt("price", 600);
        //var midGrandeGuitars = guitarsCollection.Find(filter);

        //var expensiveGuitars = guitarsCollection
        //.Find(global => global.Price > 400)
        //.ToList();
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
        #region Delete Uygulama
        public async Task<Movie> DeleteCommentAsync(ObjectId movieId, ObjectId commentId,
       User user, CancellationToken cancellationToken = default)
        {
            var result = _commentsCollection.DeleteOne(
                  Builders<Comment>.Filter.Where(
                     c => c.MovieId == movieId
                           && c.Id == commentId
                           && c.Email == user.Email));

            return await _moviesRepository.GetMovieAsync(movieId.ToString(), cancellationToken);
        }
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


        #region Group Örnek Uygulama
        public async Task<TopCommentsProjection> MostActiveCommentersAsync()
        {
            try
            {
                List<ReportProjection> result = null;

                result = await _commentsCollection
                   .WithReadConcern(ReadConcern.Majority)
                   .Aggregate()
                   .Group(new BsonDocument
                   {
               {"_id", "$email"},
               {"count", new BsonDocument("$sum", 1)}
                   })
                   .Sort(Builders<BsonDocument>.Sort.Descending("count"))
                   .Limit(20)
                   .Project<ReportProjection>(Builders<BsonDocument>.Projection.Include("email").Include("count"))
                   .ToListAsync();

                return new TopCommentsProjection(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        #endregion


        #region Son uygulama migration
        //    var bulkWriteDatesResult = await _moviesCollection.BulkWriteAsync(
        //   datePipelineResults.Select(updatedMovie => new ReplaceOneModel<Movie>(
        //      new FilterDefinitionBuilder<Movie>().Where(m => m.Id == updatedMovie.Id),
        //      updatedMovie)));

        //...

        //var bulkWriteRatingsResult = await _moviesCollection.BulkWriteAsync(
        //   ratingPipelineResults.Select(updatedMovie => new ReplaceOneModel<Movie>(
        //      new FilterDefinitionBuilder<Movie>().Where(m => m.Id == updatedMovie.Id),
        //      updatedMovie)));
        #endregion


        #region Connection Pooling
        //appsettings de connection string aşşağıdaki gibi düznlenerek connection pooling ayarlanabilir
        //"MongoUri": "mongodb+srv://kaan:111222333@mflix.ulybz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority",
        //"MongoUri": "mongodb+srv://kaan:111222333@mflix.ulybz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority&maxpoolsize=50",

        #endregion


        #region WriteTimeOut
        //"MongoUri": "mongodb+srv://m220student:m220student@mflix-12345.mongodb.net/sample_mflix?maxPoolSize=50"
        //"MongoUri": "mongodb+srv://m220student:m220student@mflix-12345.mongodb.net/sample_mflix?maxPoolSize=50&wtimeoutMS=2500"
        #endregion


        #region Çalışmasada user ekleme kodu
        //  db.createUser({
        //  user : "mflixAppUser",
        //  pwd : "mflixAppPwd",
        //  roles : [{
        //      role : "readWrite", db:"sample_mflix"
        //    }]
        //})
        #endregion


        #region Bölüm Sonu Soruları
        #region Soru 1
        //colElections.Find<BsonDocument>("{ winner_party: "Republican", winner_electoral_votes: { "$gte": 160 } }");
        #endregion
        #region Soru 2
        // colPhones.UpdateMany(
        //Builders<Phone>.Filter.Lt(p => p.SoftwareVersion, 4.0),
        //Builders<Phone>.Update.Set(p => p.UpdateRequired, true));
        #endregion
        #region SoruSon
        //people.Find(Builders<People>.Filter.Empty)
        //.Sort(Builders<People>.Sort.Descending(p => p.Height))
        //.Skip(3)
        //.Limit(2);
        #endregion

        #endregion


        #endregion


        #region Mongo Aggregation Framework
        #region $match:Filtering Document
        //You can use nearly all of the familiar query operators in $match.We filter documents, retaining only those where the imdb.rating is 7 or more,
        //genres does not include "Crime" or "Horror", the value for rated was "PG" or "G", and languages includes both "English" and "Japanese". .. code-block:

        //    var pipeline = [
        //  {
        //    $match: {
        //      "imdb.rating": { $gte: 7 },
        //      genres: { $nin:[ "Crime", "Horror" ] } ,
        //      rated: { $in: ["PG", "G" ] },
        //      languages: { $all:[ "English", "Japanese" ] }
        //    }
        //  }
        //]
        #endregion


        #region Shaping Document with $project
        //{$multiply : [gravityRatio, weightOnEarth]}
        //{$divide : ["$gravity.value", weightOnEarth]}

        //db.solarSystem.aggregate([{
        //    $project:
        //    {
        //        _id: 0,
        //        name: 1,
        //        myWeight: { $multiply :[{ $divide: ["$gravity.value", 9.8]},86]}
        //    }
        //}])

        //var pipeline = [{ $match: {. . .} }, { $project: { . . . } }]

        //    var pipeline = [
        //  {
        //    $match: {
        //      "imdb.rating": { $gte: 7 },
        //      genres: { $nin:[ "Crime", "Horror" ] } ,
        //      rated: { $in: ["PG", "G" ] },
        //      languages: { $all:[ "English", "Japanese" ] }
        //    }
        //  },
        //  {
        //    $project: { _id: 0, title: 1, "rated": 1 }
        //}
        //]

        //db.movies.aggregate([...]).itcount()

        //    db.movies.aggregate([
        //  {
        //    $match: {
        //      title: {
        //        $type: "string"
        //      }
        //    }
        //  },
        //  {
        //    $project:
        //    {
        //    title: { $split:["$title", " "] },
        //      _id: 0
        //    }
        //},
        //  {
        //    $match:
        //    {
        //    title: { $size: 1 }
        //    }
        //}
        //]).itcount()

        //{ $match: { writers: { $elemMatch: { $exists: true } } }

        //    writers: {
        //  $map: {
        //    input: "$writers",
        //    as: "writer",
        //    in: {
        //      $arrayElemAt: [
        //        {
        //          $split: [ "$$writer", " (" ]
        //},
        //        0
        //      ]
        //    }
        //  }
        //}


        //    db.movies.aggregate([
        //  {
        //    $match: {
        //      cast: { $elemMatch: { $exists: true } },
        //      directors: { $elemMatch: { $exists: true } },
        //      writers: { $elemMatch: { $exists: true } }
        //    }
        //  },
        //  {
        //    $project:
        //    {
        //    _id: 0,
        //      cast: 1,
        //      directors: 1,
        //      writers:
        //        {
        //        $map:
        //            {
        //            input: "$writers",
        //          as: "writer",
        //          in: {
        //            $arrayElemAt:
        //                    [
        //              {
        //                $split:["$$writer", " ("]
        //              },
        //              0
        //            ]
        //          }
        //            }
        //        }
        //    }
        //},
        //  {
        //    $project:
        //    {
        //    labor_of_love:
        //        {
        //        $gt:
        //            [
        //          { $size: { $setIntersection:["$cast", "$directors", "$writers"] } },
        //          0
        //        ]
        //      }
        //    }
        //},
        //  {
        //    $match: { labor_of_love: true }
        //},
        //  {
        //    $count: "labors of love"
        //  }
        //])
        #endregion


        #region $geoNear Koordinta göre işlem
        //$geoNear : {
        //    near : {type : "Point", coordinates : [-73.98345345345, 40.757323423423]},
        //    distanceField : "distancefromMongoDB",
        //    minDistance : <Optional, in meters>,
        //    maxDistance : <Optional, in meters>,
        //    query : <Optional, allows querying source documents>,
        //    query : {type : "Hospital"}, // query sınırlama yaparak aramamıza yarıyor.bu da örneği
        //    includeLocs : <Optional, used to identify which location was used>,
        //    limit : <Optional, the max number of documents to return>,
        //    num : <Optional, same as limit>,
        //    spherical : true,
        //    distanceMultiplier : <Optional, the factor to multiply all distances>
        //    }
        // spherical true verdiğimizde sonuç m cinsinden false ise radyant cinsinden döner

        #endregion


        #region Cursor-like stages

        //$limit : {<integer>}
        //$skip: {<integer>}
        //$count: {<name we want the count called>}
        //$sort: {<field  we want to sort on>:<integer, direction to sort>}

        //db.solarSystem.find({}, {_id: 0, name:1, numberOfMoons: 1}).sort({ numberOfMoons: -1}).pretty()
        //db.solarSystem.find({}, {_id: 0, name:1, numberOfMoons: 1}).limit(5).pretty()


        //db.solarSystem.aggregate([{
        //    $project : {
        //        _id : 0,
        //        name : 1
        //        numberOfMoons : 1
        //        }
        //    },
        //{
        //    $skip: 1
        //}])


        //db.solarSystem.aggregate([{
        //    $project: {
        //        _id: 0,
        //        name: 1
        //        numberOfMoons: 1
        //        }
        //    },
        //    {
        //        $limit: 5
        //    }])

        //db.solarSystem.aggregate([{
        //    $project: {
        //        _id: 0,
        //        name: 1
        //        numberOfMoons: 1
        //        }
        //    },
        //    {
        //        $sort:{hasMagneticField: -1, numberOfMoons: -1}//-1 azalan desc 1 artan asc
        //    }])


        //db.solarSystem.aggregate([{
        //    $project: {
        //        _id: 0,
        //        name: 1
        //        numberOfMoons: 1
        //        }
        //    },
        //    {
        //        $sort:{hasMagneticField: -1, numberOfMoons: -1}
        //    }], {allowDiskUse:true})// Normalde db yormamak için 100 mb veriye kadar sınır var
        //  Ancak true yaparsak hafızaya limit koymadan bu işlemi yapabiliyoruz.
        //  Bu sadece sort için geçerli
        #endregion


        #region $sample Stage
        //db.nycFacilities.aggregate([{ $sample: {size:200}}]) random belli miktarda veri yollar


        //For movies released in the USA with a tomatoes.viewer.rating greater than or equal to 3, calculate a new field called num_favs that represets how many favorites appear in the cast field of the movie.
        //Sort your results by num_favs, tomatoes.viewer.rating, and title, all in descending order.
        //What is the title of the 25th film in the aggregation result?

        //    var favorites = [
        //  "Sandra Bullock",
        //  "Tom Hanks",
        //  "Julia Roberts",
        //  "Kevin Spacey",
        //  "George Clooney"]

        //db.movies.aggregate([
        //  {
        //    $match: {
        //      "tomatoes.viewer.rating": { $gte: 3 },
        //      countries: "USA",
        //      cast:
        //{
        //        $in: favorites
        //      }
        //    }
        //  },
        //  {
        //    $project:
        //    {
        //    _id: 0,
        //      title: 1,
        //      "tomatoes.viewer.rating": 1,
        //      num_favs:
        //        {
        //        $size:
        //            {
        //          $setIntersection:[
        //            "$cast",
        //            favorites
        //          ]
        //        }
        //        }
        //    }
        //},
        //  {
        //    $sort: { num_favs: -1, "tomatoes.viewer.rating": -1, title: -1 }
        //},
        //  {
        //    $skip: 24
        //  },
        //  {
        //    $limit: 1
        //  }
        //])


        //****************************************
        //Calculate an average rating for each movie in our collection where English is an available language, the minimum imdb.rating is at least 1, the minimum imdb.votes is at least 1, and it was released in 1990 or after.You'll be required to rescale (or normalize) imdb.votes. The formula to rescale imdb.votes and calculate normalized_rating is included as a handout.
        //What film has the lowest normalized_rating?

        //    db.movies.aggregate([
        //  {
        //    $match: {
        //      year: { $gte: 1990 },
        //      languages: { $in: ["English"] },
        //      "imdb.votes": { $gte: 1 },
        //      "imdb.rating": { $gte: 1 }
        //    }
        //  },
        //  {
        //    $project:
        //    {
        //    _id: 0,
        //      title: 1,
        //      "imdb.rating": 1,
        //      "imdb.votes": 1,
        //      normalized_rating:
        //        {
        //        $avg:[
        //          "$imdb.rating",
        //          {
        //            $add:[
        //              1,
        //              {
        //                $multiply:[
        //                  9,
        //                  {
        //                    $divide:
        //                        [
        //                      { $subtract:["$imdb.votes", 5] },
        //                      { $subtract:[1521105, 5] }
        //                    ]
        //                  }
        //                ]
        //              }
        //            ]
        //          }
        //        ]
        //      }
        //    }
        //},
        //  { $sort: { normalized_rating: 1 } },
        //  { $limit: 1 }
        //])
        #endregion


        #region $group Stage
        //db.movies.aggregate([
        //    {
        //    $group : {
        //        _id: "year",
        //        num_films_in_year: {$sum:1}
        //        }
        //    }])


        //db.movies.aggregate([
        //    {
        //    $group : {
        //        _id: {
        //          numDirectors: {
        //              $cond: [{$isArray: "$directors"},{$size:"directors"},0]
        //              }
        //          },
        //          numFilms: {$sum:1},
        //          avarageMetacritic: { $avg: "$metacritic"}
        //          }
        //          },{
        //              $sort: { "_id.numDirectors":-1}
        //          }
        //          ])
        #endregion


        #region Accumulator Stages With $project
        // db.iceCream.aggregate([
        //     {
        //     $project:{
        //         _id:0,
        //         max_high:{
        //             $reduce:{
        //                 input:"$trends",
        //                 initialValue: -Infinity,
        //                 in:{
        //                     $cond:[
        //                         {$gt:["$$this.avg_high_tmp", "$$value"]},
        //                         "$$this.avg_high_tmp",
        //                         "$$value" //gt doğru ise birinci değilse value yi atıyor
        //                         ]
        //                     }
        //                 }
        //             }
        //         }
        //     }
        //])


        //db.iceCream.aggregate([
        //    {$project: {_id:0, max_high:{$max:{"$trends.avg_high_tmp"}}}}
        //    ])


        //db.iceCream.aggregate([
        //    {
        //        $project : {
        //            _id:0,
        //            average_cpi:{$avg: "$trends.icecream_cpi"},
        //            cpi_deviation: {$stdDevPop: "$trends.icecream_cpi" }
        //            }//standart sapma   
        //    }
        //    ])


        //    db.movies.aggregate([
        //  {
        //    $match: {
        //      awards: /Won \d{1,2} Oscars ?/
        //    }
        //  },
        //  {
        //    $group:
        //    {
        //    _id: null,
        //      highest_rating: { $max: "$imdb.rating" },
        //      lowest_rating: { $min: "$imdb.rating" },
        //      average_rating: { $avg: "$imdb.rating" },
        //      deviation: { $stdDevSamp: "$imdb.rating" }
        //    }
        //}
        //])
        #endregion


        #region $unwind Stage//Dizileri parçalayarak yeni bir collection oluşturur.
        //collectiondaki a dizisini unwind edersek a dizisini elemanlarına ayırıp
        //collectionı değiştirir
        //db.movies.aggregate([
        //    {
        //    $match:{
        //        "imdb.rating": {$gt:0},
        //        year: {$gte: 2010,$lte: 2015 },
        //        runtime: {$gte:90 }
        //        }
        //    },
        //    {
        //    $unwind:"genres"   
        //    },
        //    {
        //    $group:
        //    {
        //    _id: {
        //        year: "$year",
        //                genre: "$genres"
        //                },
        //            avarage_rating: {$avg: "imdb.rating" }
        //            }   
        //    },
        //    { 
        //    $sort: {"_id.year":-1,"average_rating:-1" }
        //    },
        //    {
        //    $group: { 
        //        _id:"$id.year",
        //         genre: { $first: "$id.genre"},
        //         avarage_rating: { $first:"$average_rating"}
        //        }
        //    },
        //    {
        //    $sort: { _id:-1}
        //    }
        //])



        //    db.movies.aggregate([
        //  {
        //    $match: {
        //      languages: "English"
        //    }
        //  },
        //  {
        //    $project: { _id: 0, cast: 1, "imdb.rating": 1 }
        //},
        //  {
        //    $unwind: "$cast"
        //  },
        //  {
        //    $group:
        //    {
        //    _id: "$cast",
        //      numFilms: { $sum: 1 },
        //      average: { $avg: "$imdb.rating" }
        //    }
        //},
        //  {
        //    $project:
        //    {
        //    numFilms: 1,
        //      average:
        //        {
        //        $divide:[{ $trunc: { $multiply:["$average", 10] } }, 10]
        //      }
        //    }
        //},
        //  {
        //    $sort: { numFilms: -1 }
        //},
        //  {
        //    $limit: 1
        //  }
        //])
        #endregion


        #region $lookup Stage
        //Which alliance from air_alliances flies the most routes with either a Boeing 747 or an Airbus A380(abbreviated 747 and 380 in air_routes)?

        //        db.air_routes.aggregate([
        //  {
        //    $match: {
        //      airplane: /747|380/
        //    }
        //},
        //  {
        //    $lookup:
        //    {
        //    from: "air_alliances",
        //      foreignField: "airlines",
        //      localField: "airline.name",
        //      as: "alliance"
        //    }
        //},
        //  {
        //    $unwind: "$alliance"
        //  },
        //  {
        //    $group:
        //    {
        //    _id: "$alliance.name",
        //      count: { $sum: 1 }
        //    }
        //},
        //  {
        //    $sort: { count: -1 }
        //}
        //])
        #endregion


        #region $graphLookup
        //$graphLookup:{
        //    from:<lookup table>,
        //    startWith:<expression for value to start from>,
        //    connectFromField:<field name to connect from>,
        //    connectToField:<field name to connect to>,
        //    as:<field name for result array>,
        //    maxDepth:<optional-number of iterations to perform>,
        //    depthField:<optional-field name for number of iterations to reach this node>
        //    restrictSearchWithMatch:<optional-match condition to apply to lookup>
        //    }

        //Üstten alta
        //db.parent_reference.aggregate([
        //    {
        //    $match:{name:'Eliot'}
        //    },
        //    {
        //        $graphLookup:
        //        {
        //        from: 'parent_reference',
        //                startWith: '$_id',
        //                connectFromField: '_id',
        //                connectToField: 'reports_to',
        //                as: 'all_reports'
        //        }
        //    }
        //    ])

        //Alttanüste
        //db.parent.reference.aggregate([
        //    {
        //    $match:{name:'Shannon'}
        //    },
        //    {
        //        $graphLookup:
        //        {
        //            from:'parent_reference',
        //                startWith:'$reports_to',
        //                connectFromField:'reports_to',
        //                connectToField:'_id',
        //                as: 'bosses'
        //        }
        //    }
        //    ])


        //Reverse Schema
        //db.parent.reference.aggregate([
        //    {
        //    $match:{name:'Dev'}
        //    },
        //    {
        //        $graphLookup:
        //        {
        //            from:'child_reference',
        //                startWith:'$direct_reports',
        //                connectFromField:'direct_reports',
        //                connectToField:'name',
        //                as: 'all_reports'
        //        }
        //    }
        //    ])
        #endregion


        #region $graphLookup: maxDepth and depthField
        //db.child_reference.aggregate([
        //    {$match:{name:'Dev'}},
        //        {$graphLookup: { 
        //            from:'child_reference',
        //            startWith:'$direct_reports',
        //            connectFromField:'direct_reports',
        //            connectToField:'name',
        //            as:'till_2_level_reports',
        //            maxDepth: 1//maxdepth gideceği child yada parent sayısını seçer. 0 da bir aşşağı yada yukarı
        //        } }
        //    ]).pretty()


        //db.child_reference.aggregate([
        //    {$match:{name:'Dev'}},
        //        {$graphLookup: { 
        //            from:'child_reference',
        //            startWith:'$direct_reports',
        //            connectFromField:'direct_reports',
        //            connectToField:'name',
        //            as:'descendants',
        //            maxDepth: 1,//maxdepth gideceği child yada parent sayısını seçer. 0 da bir aşşağı yada yukarı
        //            depthField:'level'//kaçıncı childda oldğu bilgisini veriyor
        //        } }
        //    ]).pretty()
        #endregion
        #region $graphLookUp soru cevap
        //        db.air_alliances.aggregate([
        //  {
        //    $match: { name: "OneWorld" }
        //},
        //  {
        //    $graphLookup:
        //    {
        //    startWith: "$airlines",
        //      from: "air_airlines",
        //      connectFromField: "name",
        //      connectToField: "name",
        //      as: "airlines",
        //      maxDepth: 0,
        //      restrictSearchWithMatch:
        //        {
        //        country: { $in: ["Germany", "Spain", "Canada"] }
        //        }
        //    }
        //},
        //  {
        //    $graphLookup:
        //    {
        //    startWith: "$airlines.base",
        //      from: "air_routes",
        //      connectFromField: "dst_airport",
        //      connectToField: "src_airport",
        //      as: "connections",
        //      maxDepth: 1
        //    }
        //},
        //  {
        //    $project:
        //    {
        //    validAirlines: "$airlines.name",
        //      "connections.dst_airport": 1,
        //      "connections.airline.name": 1
        //    }
        //},
        //  { $unwind: "$connections" },
        //  {
        //    $project:
        //    {
        //    isValid:
        //        {
        //        $in: ["$connections.airline.name", "$validAirlines"]
        //      },
        //      "connections.dst_airport": 1
        //    }
        //},
        //  { $match: { isValid: true } },
        //  {
        //    $group:
        //    {
        //    _id: "$connections.dst_airport"
        //    }
        //}
        //])
        #endregion



        #endregion


    }
}
