FROM ubuntu:16.04
WORKDIR /dotnet
ENV MYSQL_ROOT_PASSWORD=root
ENV MYSQL_ROOT_P=root
RUN apt update
RUN apt -y upgrade
RUN apt install -y build-essential net-tools wget curl apt-transport-https lsb-release
RUN wget https://dev.mysql.com/get/mysql-apt-config_0.8.10-1_all.deb
RUN dpkg -i mysql-apt-config_0.8.10-1_all.deb
RUN echo "mysql-server-5.6 mysql-server/root_password password root" | debconf-set-selections
RUN echo "mysql-server-5.6 mysql-server/root_password_again password root" | debconf-set-selections
RUN apt install -y mysql-client
RUN apt install -y mysql-server
RUN wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb 
RUN dpkg -i packages-microsoft-prod.deb
RUN apt update
RUN apt install -y apt-transport-https
RUN apt install -y dotnet-sdk-2.2
# RUN /etc/init.d/mysql status
# RUN /etc/init.d/mysql start
# RUN /etc/init.d/mysql status
# RUN mysql -u root -proot -e "CREATE DATABASE homesdb"
# RUN mysql -u root -proot -e "CREATE DATABASE usersdb"
# RUN mysql -u root -proot -e "CREATE DATABASE maindb"
# RUN mysql -u root -proot -e "CREATE DATABASE kapi"
ENTRYPOINT ["/etc/init.d/mysql", "start"]