# Ambev.DeveloperEvaluation

### Auth

#### POST /api/Auth
**Descrição:**  
Endpoint para autenticar um usuário. Envie o e-mail e a senha para receber um token de acesso e dados do usuário autenticado.

**Exemplo de Payload (Request):**
```json
{
  "email": "user@example.com",
  "password": "Password123!"
}
```

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Authentication successful",
  "data": {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "email": "user@example.com",
    "name": "John Doe",
    "role": "User"
  }
}
```

---

### Branches

#### GET /api/Branches
**Descrição:**  
Obtém uma lista paginada de filiais. Use os parâmetros `Page`, `Size` e `Order` para controlar a paginação e a ordenação.

**Exemplo de Chamada:**  
`GET /api/Branches?Page=1&Size=10&Order=asc`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Branches retrieved successfully",
  "data": {
    "categories": [
      {
        "id": "123e4567-e89b-12d3-a456-426614174000",
        "name": "Filial Central",
        "location": "Centro"
      }
    ],
    "totalCount": 1,
    "currentPage": 1,
    "totalPages": 1
  }
}
```

#### POST /api/Branches
**Descrição:**  
Cria uma nova filial.

**Exemplo de Payload (Request):**
```json
{
  "name": "Filial Central",
  "location": "Centro"
}
```

**Exemplo de Resposta (201 Created):**
```json
{
  "success": true,
  "message": "Branch created successfully",
  "data": {
    "id": "generated-uuid",
    "name": "Filial Central",
    "location": "Centro"
  }
}
```

#### GET /api/Branches/{id}
**Descrição:**  
Recupera os detalhes de uma filial específica, utilizando seu identificador.

**Exemplo de Chamada:**  
`GET /api/Branches/123e4567-e89b-12d3-a456-426614174000`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Branch details retrieved",
  "data": {
    "id": "123e4567-e89b-12d3-a456-426614174000",
    "name": "Filial Central",
    "location": "Centro"
  }
}
```

#### PUT /api/Branches/{id}
**Descrição:**  
Atualiza os dados de uma filial específica.

**Exemplo de Payload (Request):**
```json
{
  "name": "Filial Atualizada",
  "location": "Novo Centro"
}
```

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Branch updated successfully",
  "data": {
    "id": "123e4567-e89b-12d3-a456-426614174000",
    "name": "Filial Atualizada",
    "location": "Novo Centro"
  }
}
```

#### DELETE /api/Branches/{id}
**Descrição:**  
Remove uma filial pelo seu identificador.

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Branch deleted successfully"
}
```

---

### Carts

#### GET /api/Carts
**Descrição:**  
Obtém os carrinhos de compra. Utilize os parâmetros `_page`, `_size` e `_order` para controle de paginação.

**Exemplo de Chamada:**  
`GET /api/Carts?_page=1&_size=10&_order=asc`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Carts retrieved successfully",
  "data": {
    "id": "cart-uuid",
    "userId": "user-uuid",
    "date": "2025-03-05T12:00:00Z",
    "products": [
      {
        "productId": "product-uuid",
        "quantity": 2
      }
    ]
  }
}
```

#### POST /api/Carts
**Descrição:**  
Cria um novo carrinho de compras para um usuário.

**Exemplo de Payload (Request):**
```json
{
  "userId": "user-uuid",
  "products": [
    {
      "productId": "product-uuid",
      "quantity": 3
    }
  ]
}
```

**Exemplo de Resposta (201 Created):**
```json
{
  "success": true,
  "message": "Cart created successfully",
  "data": {
    "id": "generated-cart-uuid",
    "userId": "user-uuid",
    "createdAt": "2025-03-05T12:00:00Z",
    "products": [
      {
        "productId": "product-uuid",
        "quantity": 3
      }
    ]
  }
}
```

#### GET /api/Carts/{id}
**Descrição:**  
Recupera os detalhes de um carrinho específico.

**Exemplo de Chamada:**  
`GET /api/Carts/abc-uuid`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Cart details retrieved",
  "data": {
    "id": "abc-uuid",
    "userId": "user-uuid",
    "createdAt": "2025-03-05T12:00:00Z",
    "products": [
      {
        "id": "cartitem-uuid",
        "productId": "product-uuid",
        "quantity": 3
      }
    ]
  }
}
```

#### PUT /api/Carts/{id}
**Descrição:**  
Atualiza um carrinho existente, podendo alterar a quantidade dos produtos.

**Exemplo de Payload (Request):**
```json
{
  "id": "cart-uuid",
  "userId": "user-uuid",
  "products": [
    {
      "productId": "product-uuid",
      "quantity": 5
    }
  ]
}
```

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Cart updated successfully",
  "data": {
    "id": "cart-uuid",
    "updatedAt": "2025-03-05T12:30:00Z",
    "products": [
      {
        "productId": "product-uuid",
        "quantity": 5
      }
    ]
  }
}
```

#### DELETE /api/Carts/{id}
**Descrição:**  
Exclui um carrinho de compras pelo seu identificador.

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Cart deleted successfully"
}
```

---

### Categories

#### GET /api/Categories
**Descrição:**  
Recupera uma lista paginada de categorias. Parâmetros: `Page`, `Size` e `Order`.

**Exemplo de Chamada:**  
`GET /api/Categories?Page=1&Size=10&Order=asc`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Categories retrieved successfully",
  "data": {
    "categories": [
      {
        "id": "category-uuid",
        "name": "Beverages",
        "description": "Drinks and more"
      }
    ],
    "totalCount": 1,
    "currentPage": 1,
    "totalPages": 1
  }
}
```

#### POST /api/Categories
**Descrição:**  
Cria uma nova categoria.

**Exemplo de Payload (Request):**
```json
{
  "name": "Beverages",
  "description": "Drinks and more"
}
```

**Exemplo de Resposta (201 Created):**
```json
{
  "success": true,
  "message": "Category created successfully",
  "data": {
    "id": "generated-category-uuid",
    "name": "Beverages",
    "description": "Drinks and more"
  }
}
```

#### GET /api/Categories/{id}
**Descrição:**  
Recupera os detalhes de uma categoria específica.

**Exemplo de Chamada:**  
`GET /api/Categories/category-uuid`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Category details retrieved",
  "data": {
    "id": "category-uuid",
    "name": "Beverages",
    "description": "Drinks and more"
  }
}
```

#### PUT /api/Categories/{id}
**Descrição:**  
Atualiza as informações de uma categoria.

**Exemplo de Payload (Request):**
```json
{
  "name": "Updated Category",
  "description": "Updated description"
}
```

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Category updated successfully",
  "data": {
    "id": "category-uuid",
    "name": "Updated Category",
    "description": "Updated description",
    "updatedAt": "2025-03-05T13:00:00Z"
  }
}
```

#### DELETE /api/Categories/{id}
**Descrição:**  
Exclui uma categoria com base no identificador.

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Category deleted successfully"
}
```

---

### Customers

#### POST /api/Customers
**Descrição:**  
Cria um novo cliente, associando-o a um usuário.

**Exemplo de Payload (Request):**
```json
{
  "userId": "user-uuid",
  "externalId": "external-identifier"
}
```

**Exemplo de Resposta (201 Created):**
```json
{
  "success": true,
  "message": "Customer created successfully",
  "data": {
    "id": "generated-customer-uuid"
  }
}
```

#### GET /api/Customers
**Descrição:**  
Recupera os detalhes de um cliente a partir do `userId` informado.

**Exemplo de Chamada:**  
`GET /api/Customers?userId=user-uuid`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Customer details retrieved",
  "data": {
    "id": "customer-uuid",
    "externalId": "external-identifier",
    "name": "Customer Name",
    "userId": "user-uuid"
  }
}
```

---

### Products

#### GET /api/Products/{id}
**Descrição:**  
Recupera os detalhes de um produto específico pelo seu identificador.

**Exemplo de Chamada:**  
`GET /api/Products/product-uuid`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Product retrieved successfully",
  "data": {
    "id": "product-uuid",
    "title": "Product Title",
    "price": 19.99,
    "description": "Product description",
    "category": "Category Name",
    "image": "http://example.com/image.png",
    "rating": {
      "rate": 4.5,
      "count": 100
    }
  }
}
```

#### DELETE /api/Products/{id}
**Descrição:**  
Remove um produto pelo seu identificador.

**Exemplo de Resposta (204 No Content ou 200 OK):**
```json
{
  "success": true,
  "message": "Product deleted successfully"
}
```

#### GET /api/Products
**Descrição:**  
Recupera uma lista paginada de produtos. Parâmetros: `_order`, `_page` e `_size`.

**Exemplo de Chamada:**  
`GET /api/Products?_order=asc&_page=1&_size=10`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Products retrieved successfully",
  "data": [
    {
      "products": [
        {
          "id": "product-uuid",
          "title": "Product Title",
          "price": 19.99,
          "description": "Product description",
          "image": "http://example.com/image.png",
          "rating": {
            "rate": 4.5,
            "count": 100
          }
        }
      ],
      "totalRecords": 1
    }
  ],
  "totalItems": 1,
  "currentPage": 1,
  "totalPages": 1
}
```

#### POST /api/Products
**Descrição:**  
Cria um novo produto.

**Exemplo de Payload (Request):**
```json
{
  "title": "New Product",
  "price": 29.99,
  "description": "Description of the new product",
  "category": "Category Name",
  "image": "http://example.com/new-image.png",
  "rating": {
    "rate": 4.0,
    "count": 50
  }
}
```

**Exemplo de Resposta (201 Created):**
```json
{
  "success": true,
  "message": "Product created successfully",
  "data": {
    "id": "generated-product-uuid",
    "title": "New Product",
    "price": 29.99,
    "description": "Description of the new product",
    "category": "Category Name",
    "image": "http://example.com/new-image.png",
    "rating": {
      "rate": 4.0,
      "count": 50
    }
  }
}
```

#### PUT /api/Products
**Descrição:**  
Atualiza os dados de um produto.

**Exemplo de Payload (Request):**
```json
{
  "id": "product-uuid",
  "title": "Updated Product Title",
  "price": 24.99,
  "description": "Updated description",
  "category": "Updated Category",
  "image": "http://example.com/updated-image.png",
  "rating": {
    "rate": 4.2,
    "count": 60
  }
}
```

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Product updated successfully",
  "data": {
    "id": "product-uuid",
    "title": "Updated Product Title",
    "price": 24.99,
    "description": "Updated description",
    "category": "Updated Category",
    "image": "http://example.com/updated-image.png",
    "rating": {
      "rate": 4.2,
      "count": 60
    }
  }
}
```

#### GET /api/Products/categories
**Descrição:**  
Recupera uma lista de categorias (strings) disponíveis para os produtos.

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Categories retrieved successfully",
  "data": [
    "Beverages",
    "Snacks",
    "Household"
  ]
}
```

#### GET /api/Products/category/{category}
**Descrição:**  
Recupera produtos que pertencem a uma categoria específica, com suporte a paginação.

**Exemplo de Chamada:**  
`GET /api/Products/category/Beverages?_page=1&_size=10&_order=asc`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Products retrieved successfully",
  "data": {
    "data": [
      {
        "id": "product-uuid",
        "title": "Product Title",
        "price": 19.99,
        "description": "Product description",
        "category": "Beverages",
        "image": "http://example.com/image.png",
        "rating": {
          "rate": 4.5,
          "count": 100
        }
      }
    ],
    "totalItems": 1,
    "currentPage": 1,
    "totalPages": 1
  }
}
```

---

### Sales

#### POST /api/Sales
**Descrição:**  
Cria uma nova venda. Inclua informações como número da venda, valor total, status de cancelamento, identificação do cliente, filial e os itens da venda.

**Exemplo de Payload (Request):**
```json
{
  "saleNumber": "S123456",
  "totalAmount": 99.99,
  "isCancelled": false,
  "customerId": "customer-uuid",
  "branchId": "branch-uuid",
  "items": [
    {
      "id": "item-uuid",
      "quantity": 2,
      "unitPrice": 49.99,
      "discount": 0,
      "totalItemAmount": 99.98,
      "productId": "product-uuid"
    }
  ]
}
```

**Exemplo de Resposta (201 Created):**
```json
{
  "success": true,
  "message": "Sale created successfully",
  "data": {
    "id": "generated-sale-uuid",
    "saleNumber": "S123456",
    "totalAmount": 99.99,
    "isCancelled": false,
    "customerId": "customer-uuid",
    "branchId": "branch-uuid"
  }
}
```

#### GET /api/Sales
**Descrição:**  
Recupera uma lista de vendas.

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Sales retrieved successfully",
  "data": [
    {
      "id": "sale-uuid",
      "saleNumber": "S123456",
      "totalAmount": 99.99,
      "isCancelled": false,
      "customerId": "customer-uuid",
      "branchId": "branch-uuid",
      "createdAt": "2025-03-05T12:00:00Z",
      "items": []
    }
  ]
}
```

#### GET /api/Sales/{id}
**Descrição:**  
Recupera os detalhes de uma venda específica.

**Exemplo de Chamada:**  
`GET /api/Sales/sale-uuid`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Sale details retrieved",
  "data": {
    "id": "sale-uuid",
    "saleNumber": "S123456",
    "totalAmount": 99.99,
    "isCancelled": false,
    "customerId": "customer-uuid",
    "branchId": "branch-uuid",
    "createdAt": "2025-03-05T12:00:00Z",
    "items": [
      {
        "id": "item-uuid",
        "quantity": 2,
        "unitPrice": 49.99,
        "discount": 0,
        "totalItemAmount": 99.98,
        "productId": "product-uuid"
      }
    ]
  }
}
```

#### PUT /api/Sales/{id}
**Descrição:**  
Atualiza os dados de uma venda existente.

**Exemplo de Payload (Request):**
```json
{
  "saleNumber": "S123456-UPDATED",
  "totalAmount": 89.99,
  "isCancelled": false,
  "customerId": "customer-uuid",
  "branchId": "branch-uuid",
  "items": [
    {
      "id": "item-uuid",
      "quantity": 2,
      "unitPrice": 44.99,
      "discount": 0,
      "totalItemAmount": 89.98,
      "productId": "product-uuid"
    }
  ]
}
```

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Sale updated successfully",
  "data": {
    "id": "sale-uuid"
  }
}
```

#### DELETE /api/Sales/{id}
**Descrição:**  
Exclui uma venda pelo seu identificador.

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Sale deleted successfully"
}
```

#### PATCH /api/Sales/cancel/{id}
**Descrição:**  
Cancela uma venda específica.

**Exemplo de Chamada:**  
`PATCH /api/Sales/cancel/sale-uuid`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Sale cancelled successfully"
}
```

#### PATCH /api/Sales/cancel-item/{saleId}/{itemId}
**Descrição:**  
Cancela um item específico de uma venda.

**Exemplo de Chamada:**  
`PATCH /api/Sales/cancel-item/sale-uuid/item-uuid`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Sale item cancelled successfully"
}
```

---

### Users

#### POST /api/Users
**Descrição:**  
Cria um novo usuário na plataforma.

**Exemplo de Payload (Request):**
```json
{
  "username": "johndoe",
  "password": "SecurePass123",
  "phone": "1234567890",
  "email": "john@example.com",
  "status": 1,
  "role": 2,
  "name": {
    "firstname": "John",
    "lastname": "Doe"
  },
  "address": {
    "city": "CityName",
    "street": "StreetName",
    "number": 123,
    "zipcode": "12345",
    "geolocation": {
      "lat": "40.7128",
      "long": "-74.0060"
    }
  }
}
```

**Exemplo de Resposta (201 Created):**
```json
{
  "success": true,
  "message": "User created successfully",
  "data": {
    "id": "generated-user-uuid",
    "email": "john@example.com",
    "username": "johndoe",
    "password": "hashed-password",
    "name": {
      "firstname": "John",
      "lastname": "Doe"
    },
    "address": {
      "city": "CityName",
      "street": "StreetName",
      "number": 123,
      "zipcode": "12345",
      "geolocation": {
        "lat": "40.7128",
        "long": "-74.0060"
      }
    },
    "phone": "1234567890",
    "status": 1,
    "role": 2
  }
}
```

#### GET /api/Users
**Descrição:**  
Recupera uma lista paginada de usuários. Parâmetros: `_page`, `_size` e `_order`.

**Exemplo de Chamada:**  
`GET /api/Users?_page=1&_size=10&_order=asc`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "Users retrieved successfully",
  "data": {
    "users": [
      {
        "id": "user-uuid",
        "email": "john@example.com",
        "username": "johndoe",
        "password": "hashed-password",
        "name": {
          "firstname": "John",
          "lastname": "Doe"
        },
        "address": {
          "city": "CityName",
          "street": "StreetName",
          "number": 123,
          "zipcode": "12345",
          "geolocation": {
            "lat": "40.7128",
            "long": "-74.0060"
          }
        },
        "phone": "1234567890",
        "status": 1,
        "role": 2
      }
    ]
  }
}
```

#### PUT /api/Users/{id}
**Descrição:**  
Atualiza os dados de um usuário existente.

**Exemplo de Payload (Request):**
```json
{
  "email": "john.new@example.com",
  "username": "john_doe_updated",
  "password": "NewSecurePass456",
  "name": {
    "firstname": "John",
    "lastname": "Doe Updated"
  },
  "address": {
    "city": "NewCity",
    "street": "NewStreet",
    "number": 456,
    "zipcode": "67890",
    "geolocation": {
      "lat": "41.0000",
      "long": "-75.0000"
    }
  },
  "phone": "0987654321",
  "status": 1,
  "role": 2
}
```

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "User updated successfully",
  "data": {
    "id": "user-uuid",
    "username": "john_doe_updated",
    "email": "john.new@example.com",
    "phone": "0987654321",
    "password": "hashed-new-password",
    "role": 2,
    "status": 1,
    "name": {
      "firstname": "John",
      "lastname": "Doe Updated"
    },
    "address": {
      "city": "NewCity",
      "street": "NewStreet",
      "number": 456,
      "zipcode": "67890",
      "geolocation": {
        "lat": "41.0000",
        "long": "-75.0000"
      }
    },
    "createdAt": "2025-03-05T12:00:00Z",
    "updatedAt": "2025-03-05T13:00:00Z"
  }
}
```

#### GET /api/Users/{id}
**Descrição:**  
Recupera os detalhes de um usuário específico.

**Exemplo de Chamada:**  
`GET /api/Users/user-uuid`

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "User details retrieved",
  "data": {
    "id": "user-uuid",
    "email": "john@example.com",
    "username": "johndoe",
    "password": "hashed-password",
    "name": {
      "firstname": "John",
      "lastname": "Doe"
    },
    "address": {
      "city": "CityName",
      "street": "StreetName",
      "number": 123,
      "zipcode": "12345",
      "geolocation": {
        "lat": "40.7128",
        "long": "-74.0060"
      }
    },
    "phone": "1234567890",
    "status": 1,
    "role": 2
  }
}
```

#### DELETE /api/Users/{id}
**Descrição:**  
Remove um usuário com base no seu identificador.

**Exemplo de Resposta (200 OK):**
```json
{
  "success": true,
  "message": "User deleted successfully"
}
```

---

Este documento serve como um guia básico para entender o uso dos endpoints da API com exemplos de payload e respostas. Você pode adaptar e expandir conforme necessário, incluindo mais detalhes sobre possíveis mensagens de erro ou outros cenários específicos de negócio.