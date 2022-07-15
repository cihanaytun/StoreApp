                                          --- Angular json ---


Added ssl to the serve section
         
            "options": {
              "browserTarget": "client:build",
              "sslKey": "ssl/server.key",
              "sslCert": "ssl/server.crt",
              "ssl": true
            },

-----------------------------------------------------------------------
ng add ngx-bootstrap                 |
npm i ngx-bootstrap		     |  install
npm i font-awesome		     |
npm install bootstrap@5.2.0-beta1    |


------------------------------------------------------------------------
add style section

            "styles": [
              "./node_modules/bootstrap/dist/css/bootstrap.min.css",
              "./node_modules/ngx-bootstrap/datepicker/bs-datepicker.css",
              "./node_modules/font-awesome/css/font-awesome.min.css",
              "src/styles.scss"
            ],
------------------------------------------------------------------------