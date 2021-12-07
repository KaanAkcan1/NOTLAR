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


    }
}
