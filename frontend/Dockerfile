# NGINX Docker image based on the Alpine Linux distribution.
FROM nginx:alpine
# Copy the index.html file to the Docker container where NGINX serves static files
# (directly served to the client's web browser, without anything on the server side).
COPY ./index.html /usr/share/nginx/html/index.html
COPY ./fetchBooks.js /usr/share/nginx/html/fetchBooks.js