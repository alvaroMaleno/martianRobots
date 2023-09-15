# Martian Robots API

Handling robots envy to Mars surface.

## Requirements

- .Net Core 6.0.414

## Swagger Page

- url/index.html

## Set up docker compose

    - docker build -t martianrobots:latest .
    - docker compose up
    - navigate to http://localhost:5000/index.html

## Set up via docker

    - docker build -t martianrobots:latest .
    - docker run --rm -p 5000:5000 -p 5001:5001 -e martianrobots
    - navigate to http://localhost:5000/index.html
