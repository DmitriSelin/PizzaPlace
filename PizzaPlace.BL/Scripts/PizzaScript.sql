USE PizzaPlaceDb;

INSERT INTO Bonuses(Discount, Name)
VALUES (0, 'Null Bonus');

INSERT INTO Categories(Name)
VALUES ('Pizza');

INSERT INTO Discounts(Number, Name)
VALUES (0, 'Null Discount');

INSERT INTO Food (Price, ManufactureDate, ExpirationDate, CategoryId, Name)
VALUES (19.99, '2022-04-06', 2, 1, 'Cheese Pizza'),
(49.99, '2022-04-06', 2, 1, 'King Shrimp Pizza'),
(25.99, '2022-04-06', 2, 1, 'Vegan Pizza'),
(39.99, '2022-04-06', 2, 1, 'Sea Pizza'),
(34.99, '2022-04-06', 2, 1, 'Pepperoni Pizza'),
(42.99, '2022-04-06', 2, 1, 'Palermo Pizza'),
(25.99, '2022-04-06', 2, 1, 'Four Cheese Pizza'),
(39.99, '2022-04-06', 2, 1, 'Spicy Pizza'),
(38.99, '2022-04-06', 2, 1, 'Italian Pizza'),
(29.99, '2022-04-06', 2, 1, 'Mushroom Pizza'),
(35.99, '2022-04-06', 2, 1, 'Village Pizza'),
(49.99, '2022-04-06', 2, 1, 'Chicago Pizza'),
(48.99, '2022-04-06', 2, 1, 'Caesar Pizza'),
(69.99, '2022-04-06', 2, 1, 'Large Meat Pizza'),
(45.99, '2022-04-06', 2, 1, 'Holiday Pizza');