# BoardController
## Base URL: /board
### Endpoints:
- 1. Get All Boards
- HTTP Method: GET
- Endpoint: /
- Description: Retrieves a list of all boards.
- Response:
- 200 OK: Returns a list of Board objects.
- 500 Internal Server Error: Returns an error message.

- 2. Get Board by ID
- HTTP Method: GET
- Endpoint: /{id}
- Description: Retrieves a board by its ID.
- Parameters:
- id: int (required) - The ID of the board to retrieve.
- Response:
- 200 OK: Returns the Board object with the specified ID.
- 404 Not Found: Returns "Board not found!" if the board does not exist.
- 500 Internal Server Error: Returns an error message.

- 3. Update Board
- HTTP Method: PUT
- Endpoint: /
- Description: Updates an existing board.
- Parameters:
- id: int (required) - The ID of the board to update.
- board: Board (required) - The updated board object.
- Response:
- 200 OK: Returns the updated Board object.
- 400 Bad Request: Returns "Board ID mismatch." if the ID in the URL does not match the board's ID.
- 404 Not Found: Returns "Board with Id = {id} not found" if the board does not exist.
- 500 Internal Server Error: Returns an error message.

- 4. Insert Board
- HTTP Method: POST
- Endpoint: /
- Description: Creates a new board.
- Parameters:
- board: Board (required) - The board object to create.
- Response:
- 201 Created: Returns the created Board object.
- 500 Internal Server Error: Returns an error message.

- 5. Delete Board
- HTTP Method: DELETE
- Endpoint: /{id}
- Description: Deletes a board by its ID.
- Parameters:
- id: int (required) - The ID of the board to delete.
- Response:
- 200 OK: Returns a message indicating the board was deleted.
- 404 Not Found: Returns "Board with Id = {id} not found" if the board does not exist.
- 500 Internal Server Error: Returns an error message.


# CardController
## Base URL: /card
### Endpoints:
- 1. Get All Cards
- HTTP Method: GET
- Endpoint: /
- Description: Retrieves a list of all cards.
- Response:
- 200 OK: Returns a list of Card objects.
- 500 Internal Server Error: Returns an error message.

- 2. Get Card by ID
- HTTP Method: GET
- Endpoint: /{id}
- Description: Retrieves a card by its ID.
- Parameters:
- id: int (required) - The ID of the card to retrieve.
- Response:
- 200 OK: Returns the Card object with the specified ID.
- 404 Not Found: Returns "Card not found!" if the card does not exist.
- 500 Internal Server Error: Returns an error message.

- 3. Update Card
- HTTP Method: PUT
- Endpoint: /
- Description: Updates an existing card.
- Parameters:
- id: int (required) - The ID of the card to update.
- card: Card (required) - The updated card object.
- Response:
- 200 OK: Returns the updated Card object.
- 400 Bad Request: Returns "Card ID mismatch." if the ID in the URL does not match the card's ID.
- 404 Not Found: Returns "Card with Id = {id} not found" if the card does not exist.
- 500 Internal Server Error: Returns an error message.

- 4. Insert Card
- HTTP Method: POST
- Endpoint: /
- Description: Creates a new card.
- Parameters:
- card: Card (required) - The card object to create.
- Response:
- 201 Created: Returns the created Card object.
- 500 Internal Server Error: Returns an error message.

- 5. Delete Card
- HTTP Method: DELETE
- Endpoint: /{id}
- Description: Deletes a card by its ID.
- Parameters:
- id: int (required) - The ID of the card to delete.
- Response:
- 200 OK: Returns a message indicating the card was deleted.
- 404 Not Found: Returns "Card with Id = {id} not found" if the card does not exist.
- 500 Internal Server Error: Returns an error message.


# SectionController
## Base URL: /section
### Endpoints:
- 1. Get All Sections
- HTTP Method: GET
- Endpoint: /
- Description: Retrieves a list of all sections.
- Response:
- 200 OK: Returns a list of Section objects.
- 500 Internal Server Error: Returns an error message.

- 2. Get Section by ID
- HTTP Method: GET
- Endpoint: /{id}
- Description: Retrieves a section by its ID.
- Parameters:
- id: int (required) - The ID of the section to retrieve.
- Response:
- 200 OK: Returns the Section object with the specified ID.
- 404 Not Found: Returns "Section not found!" if the section does not exist.
- 500 Internal Server Error: Returns an error message.

- 3. Update Section
- HTTP Method: PUT
- Endpoint: /
- Description: Updates an existing section.
- Parameters:
- id: int (required) - The ID of the section to update.
- section: Section (required) - The updated section object.
- Response:
- 200 OK: Returns the updated Section object.
- 400 Bad Request: Returns "Section ID mismatch." if the ID in the URL does not match the section's ID.
- 404 Not Found: Returns "Section with Id = {id} not found" if the section does not exist.
- 500 Internal Server Error: Returns an error message.

- 4. Insert Section
- HTTP Method: POST
- Endpoint: /
- Description: Creates a new section.
- Parameters:
- section: Section (required) - The section object to create.
- Response:
- 201 Created: Returns the created Section object.
- 500 Internal Server Error: Returns an error message.

- 5. Delete Section
- HTTP Method: DELETE
- Endpoint: /{id}
- Description: Deletes a section by its ID.
- Parameters:
- id: int (required) - The ID of the section to delete.
- Response:
- 200 OK: Returns a message indicating the section was deleted.
- 404 Not Found: Returns "Section with Id = {id} not found" if the section does not exist.
- 500 Internal Server Error: Returns an error message.

# TagController
## Base URL: /Tag
### Endpoint:
- GET /Tag
- Description: Retrieves a list of all tags.
- Response:
- 200 OK: Returns a list of Tag objects.
- 500 Internal Server Error: If an error occurs during retrieval.

- GET /Tag/{id}
- Description: Retrieves a specific tag by its ID.
- Parameters:
- id (int, required): The ID of the tag to retrieve.
- Response:
- 200 OK: Returns the Tag object with the specified ID.
- 404 Not Found: If no tag with the specified ID exists.
- 500 Internal Server Error: If an error occurs during retrieval.

- PUT /Tag
- Description: Updates an existing tag.
- Parameters:
- id (int, required): The ID of the tag to update.
- tag (Tag, required): The updated tag object.
- Response:
- 200 OK: Returns the updated Tag object.
- 400 Bad Request: If the ID in the request body does not match the ID in the URL.
- 404 Not Found: If no tag with the specified ID exists.
- 500 Internal Server Error: If an error occurs during the update.

- POST /Tag
- Description: Creates a new tag.
- Request Body:
- tag (Tag, required): The new tag object to be created.
- Response:
- 201 Created: Returns the created Tag object with its ID.
- 500 Internal Server Error: If an error occurs during creation.

- DELETE /Tag/{id}
- Description: Deletes a specific tag by its ID.
- Parameters:
- id (int, required): The ID of the tag to delete.
- Response:
- 200 OK: Confirmation that the tag was deleted.
- 404 Not Found: If no tag with the specified ID exists.
- 500 Internal Server Error: If an error occurs during deletion.

# UserController
## Base URL: /User
### Endpoint:
- GET /User
- Description: Retrieves a list of all users.
- Response:
- 200 OK: Returns a list of User objects.
- 500 Internal Server Error: If an error occurs during retrieval.

- GET /User/{id}
- Description: Retrieves a specific user by its ID.
- Parameters:
- id (int, required): The ID of the user to retrieve.
- Response:
- 200 OK: Returns the User object with the specified ID.
- 404 Not Found: If no user with the specified ID exists.
- 500 Internal Server Error: If an error occurs during retrieval.

- PUT /User
- Description: Updates an existing user.
- Parameters:
- id (int, required): The ID of the user to update.
- user (User, required): The updated user object.
- Response:
- 200 OK: Returns the updated User object.
- 400 Bad Request: If the ID in the request body does not match the ID in the URL.
- 404 Not Found: If no user with the specified ID exists.
- 500 Internal Server Error: If an error occurs during the update.

- POST /User
- Description: Creates a new user.
- Request Body:
- user (User, required): The new user object to be created.
- Response:
- 201 Created: Returns the created User object with its ID.
- 500 Internal Server Error: If an error occurs during creation.

- DELETE /User/{id}
- Description: Deletes a specific user by its ID.
- Parameters:
- id (int, required): The ID of the user to delete.
- Response:
- 200 OK: Confirmation that the user was deleted.
- 404 Not Found: If no user with the specified ID exists.
- 500 Internal Server Error: If an error occurs during deletion.