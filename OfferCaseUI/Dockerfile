# Use the official Node.js 14 image
FROM node:20-alpine AS build

# Set the working directory
WORKDIR /app
RUN npm i -g @angular/cli
# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the entire project
COPY . .

# Expose port 4200
EXPOSE 4200

# Command to start the Angular app using npm start
CMD ["npx", "ng", "serve", "--host", "0.0.0.0"]
