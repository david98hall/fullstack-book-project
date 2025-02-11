
// Fetch books when the page loads
window.onload = fetchBooks;

// Periodically check the availability of the backend
setInterval(fetchBooks, 5000); // Check every 5 seconds

async function fetchBooks() {
    try {
        const response = await fetch('http://localhost:5001/api/books');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const books = await response.json();
        const bookList = document.getElementById('book-list');
        bookList.innerHTML = '';
        books.forEach(book => {
            const listItem = document.createElement('li');
            listItem.textContent = book.title;
            bookList.appendChild(listItem);
        });
        document.getElementById('book-list').style.display = 'block';
        document.getElementById('error-message').style.display = 'none';
    } catch (error) {
        document.getElementById('book-list').style.display = 'none';
        document.getElementById('error-message').style.display = 'block';
    }
}
