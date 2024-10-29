#FROM mcr.microsoft.com/mssql/server:2019-CU13-ubuntu-20.04
FROM mcr.microsoft.com/mssql/rhel/server:2019-CU1-rhel-8
RUN mkdir -p /usr/work
WORKDIR /usr/work
COPY . /usr/work/

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false 
ENV LC_ALL=en_US.UTF-8 
ENV LANG=en_US.UTF-8

CMD /bin/bash ./entrypoint.sh

EXPOSE 1433
