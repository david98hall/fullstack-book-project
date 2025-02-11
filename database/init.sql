CREATE TABLE IF NOT EXISTS books (
    id SERIAL PRIMARY KEY, -- Each book (row) gets a unique identifier that gets incrementally larger per new row  
    title VARCHAR(255) NOT NULL
);

INSERT INTO books (title) VALUES
    ('Harry Potter'),
    ('Lord of The Rings'),
    ('Hitchhiker''s Guide to The Galaxy'),
    ('Game of Thrones'),
    ('Metro 2033'),
    ('1984');
