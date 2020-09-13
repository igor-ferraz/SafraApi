A API do Meu Negócio encapsula todos os métodos da API do safra, permitindo consulta de conta, produtos.

Server: https://safraapi.azurewebsites.net/
Login:
    [POST] {SERVER}/api/v1/user/login
    Body:
    {
        "accountId": "string",
        "password": "string"
    }

Authorization:
    [POST] {SERVER}/api/v1/auth/token
    Body: grant_type=client_credentials&scope=urn:opc:resource:consumer::all
    Headers:
        Authorization: Basic {TOKEN}
        Content-Type: application/x-www-form-urlencoded

Account:
    [GET] {SERVER}/api/v1/account/{ID}
    Headers:
        Authorization: Bearer [TOKEN]

    [GET] {SERVER}/api/v1/account/{ID}/products
    Headers:
        Authorization: Bearer [TOKEN]

    [GET] {SERVER}/api/v1/account/{ID}/balances
    Headers:
        Authorization: Bearer [TOKEN]

    [GET] {SERVER}/api/v1/account/{ID}/transactions
    Headers:
        Authorization: Bearer [TOKEN]

    [POST] {SERVER}/api/v1/account/optin
    Headers:
        Authorization: Bearer [TOKEN]
    Body:
    {
        "name": "string",
        "email": "string",
        "phone": "string"
    }
Products:
    [GET] {SERVER}/api/v1/product
    Headers:
        Authorization: Bearer [TOKEN]

    [GET] {SERVER}/api/v1/product/account/{ID}
    Headers:
        Authorization: Bearer [TOKEN]

    [POST] {SERVER}/api/v1/product
    Headers:
        Authorization: Bearer [TOKEN]
    Body:
    {
        "name": "string",
        "description": "string",
        "price": 0.00,
        "accountId": "string"
    }

    [PUT] {SERVER}/api/v1/product
    Headers:
        Authorization: Bearer [TOKEN]
    Body:
    {
        "id": 0,
        "name": "string",
        "description": "string",
        "price": 0.00,
        "accountId": "string"
    }

    [POST] {SERVER}/api/v1/product
    Headers:
        Authorization: Bearer [TOKEN]
        Content-Type: multipart/form-data
    Form:
        image: file

    [DELETE] {SERVER}/api/v1/product/{ID}
    Headers:
        Authorization: Bearer [TOKEN]


Sales:
    [POST] {SERVER}/api/v1/sale
    Headers:
        Authorization: Bearer [TOKEN]
    Body:
    {
        "accountId": "string",
        "products": [
            {
                "productId": 0,
                "quantity": 0
            }
        ]
    }