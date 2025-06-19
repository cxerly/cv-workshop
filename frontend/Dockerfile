FROM node:22-alpine AS dependencies

WORKDIR /app

COPY package*.json ./
RUN npm install


FROM node:22-alpine AS builder

WORKDIR /app

COPY --from=dependencies /app/node_modules ./node_modules
COPY . .

EXPOSE 3000

COPY run.sh run.sh

RUN chmod +x run.sh 

ENTRYPOINT ["./run.sh"]