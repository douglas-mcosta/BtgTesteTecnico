### Multi Stage Build ###

### Estágio 1 - Obter o source e gerar o build ###
FROM node:16 AS ng-builder
RUN mkdir -p /app
WORKDIR /app
COPY package.json /app
RUN npm install --legacy-peer-deps
COPY . /app
RUN $(npm bin)/ng build-azure 
###RUN npm run build-azure 


### Estágio 2 - Subir o source para o servidor NGINX com a app Angular ###
FROM nginx
COPY ./src/nginx.conf /etc/nginx/nginx.conf
COPY --from=ng-builder /app/dist/btg-app /usr/share/nginx/html

EXPOSE 80
