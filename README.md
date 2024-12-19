
# Order API Specification

## Overview
This document describes the API for managing orders in the system. The API facilitates creating, retrieving, updating, and deleting orders. It integrates with RabbitMQ for asynchronous operations, ensuring scalability and reliability.

## Endpoints

### POST /api/orders
**Summary:** Create a new order.

**Request Body**
- **Content-Type:** application/json
- **Schema:** OrderModel

**Responses**
- **202 Accepted:** Order creation started.
  - **Body:** Contains a message and the correlation ID.
- **400 Bad Request:** Invalid input (order cannot be null).

---

### GET /api/orders/{orderId}
**Summary:** Retrieve a specific order by its ID.

**Path Parameters**
- **orderId** (integer): The ID of the order to retrieve.

**Responses**
- **202 Accepted:** Order retrieval started.
  - **Body:** Contains a message and the correlation ID.
- **400 Bad Request:** Order ID is null.

---

## Schemas

### OrderModel
| Field               | Type                  | Description                                     |
|---------------------|-----------------------|-------------------------------------------------|
| id                  | integer               | Unique identifier for the order.               |
| customerId          | integer               | ID of the customer placing the order.          |
| orderDate           | string (date-time)    | Date and time when the order was placed.       |
| paymentMethod       | string                | Payment method used for the order.             |
| isPaid              | boolean               | Indicates whether the order has been paid.     |
| vipStatus           | boolean               | Indicates whether the customer has VIP status. |
| products            | array of ProductModel | List of products in the order.                 |

---

### ProductModel
| Field     | Type    | Description                              |
|-----------|---------|------------------------------------------|
| id        | integer | Unique identifier for the product.       |
| name      | string  | Name of the product.                     |
| price     | number  | Price of the product.                    |
| quantity  | integer | Quantity of the product in the order.    |


## Integration Notes
- All operations generate a unique correlation ID for tracking purposes.
- Messages are published to the `order.operations` RabbitMQ queue.
- The correlation ID and operation details are included in the published message.