const express = require("express");
const app = express();
const port = 3000;
var DB = require("./data.js");

function Send_To_Json(req,res,sql){
    DB.query(sql, null, (json_data, error) => {
                let data = error ? error: JSON.parse(json_data);
                res.set('Content-Type','application/json; charset=UTF-8');
                res.send(data);
                res.end();
            }
        );
}

app.post('/majmok', (req,res) =>{
    console.log("Majmok lekérdezése....");
    var sql = 'SELECT * FROM majom';
    Send_To_Json(req,res,sql);
});


app.listen(port, function(){console.log(`Listening at http://localhost:${port}`);});