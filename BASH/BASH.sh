#!/bin/bash

#Starting loop and adding functions

while true
do
  clear

quit_menu() {

clear

echo -e "Are you sure you want to exit? (y/n) \c"
read reply
clear
case $reply in

	y) echo " Quitting..."
	   sleep 1
	   exit ;;
	n) load_menu ;;

esac
clear
}

#Option 1
file_permissions() {
clear
echo "Permissions for this file are:"
echo "================================================================"
echo
ls -l TaskB.sh
echo "================================================================"
}
 
#Option 2
running_processes() {
clear 
echo "These are the running processes:"
echo "================================================================="
sleep 1
top -U $(whoami)
clear
}


#Main menu
load_menu() {

echo "================================================================="
echo "Hello and welcome to FDN006 Assignment 2 BASH menu created by" 
echo "student 1552603462 a.k.a bh72dh"
echo "================================================================="
echo "1. Permissions for this file."
echo "2. Running processes."
echo "3. StylishDark_mx copy/extract."
echo "4. Specific permissions search."
echo "5. Kill selected process."
echo "6. Install a program."
echo "7. Remove program."
echo "8. User menu."
echo "h. Help info."
echo "q. quit."
echo "================================================================="
}

#Option 4 
find_files() {
clear
cd /etc 
echo "These are the files  starting with pa and with the following u = rwx g = rx and o = rx permissions:"
echo "========================================================================================================="
sleep 1
find pa* -perm /u=rwx,g=rx,o=rx
sleep 1
cd ~
cd Desktop
} 

#Option 3
tar_copy() {
clear
echo "Beginning to archive files.."
sleep 1 
cd ~
cd Desktop
tar -cvf StylishDark_mx.tar /boot/grub/themes/StylishDark_mx/
sleep 1 
tar -xvf StylishDark_mx.tar -C /tmp
sleep 1 
cd ~
cd ..
cd ..
cd /tmp/boot/grub/themes/StylishDark_mx
echo "======================================================================================="
echo -e "This is where the file was extracted:"
echo
pwd
echo "======================================================================================="
sleep 1
echo "======================================================================================="
echo -e "These are the extracted files:"
echo
ls
echo "======================================================================================="
cd ~
cd Desktop
sleep 1

}

#Help message for h selection
help_msg() {
clear
echo "Please select an opttion and enter the number of the option to the menu selection "
echo "1 for option 1.. 2 for option 2.. 3 for option 3.."
echo "h for help.. q to exit" 
sleep 1
}

#Extra function of adding a user
add_user() {
clear
read -p "Enter new user:" username
output="$(grep -w $username /etc/passwd)"
if [[ -n "$output" ]] 
	then 
		 echo "This user allready exists."
	else 
		sudo useradd -m -d /bin/bash "$username"
		if [[ $? -eq 0 ]]
		then
			echo "The user $username was added successfully"
			echo "====================================================================="
			sleep 3
			tail -n 1 /etc/passwd
			echo "====================================================================="
			sleep 3
		else 
			echo "There was an error creating the new user $username"
			sleep 3
		fi
fi
}

#Extra function of deleting a user
delete_usr() {
clear
read -p "Enter the username you want to remove:" username
sudo userdel -r -f $username
sleep 2
}

#Extra function for killing a process
kill_process() {
clear
read -p "Enter the process name to kill:" process 
pkill $process
}

#Extra function for installing programs
app_install() {
clear
read -p "Enter the program name you want to install:" app
sudo apt update && sudo apt install $app
}

#Extra function for removing a program
remove_app() {
clear
read -p "Enter the program you wish to remove:" prog
sudo apt-get remove $prog 
}

#Second menu function for add/delete user
user_menu() {
while true
do
clear
echo "===================================="
echo
echo "1. Add user."
echo "2. Delete user."
echo "b. Back to main menu."
echo "===================================="
read -p "Menu selection:" selection
case $selection in
	1) add_user ;;
	2) delete_usr ;;
	b) break ;;
	*) echo " Invalid command. Press h for help." ;;
	h) help_msg ;;

esac
clear
echo -e "Enter to continue \c"
read
done
}


#Starting main menu

load_menu 

echo -e "Menu selection: \c "
read input

case $input in
	1) file_permissions ;;
	2) running_processes ;;
	3) tar_copy ;;
	4) find_files ;;
	5) kill_process ;;
	6) app_install ;;
	7) remove_app;;
	8) user_menu ;;
	q) quit_menu ;;
	h) help_msg ;;
	*) echo
	   echo "Invalid command type h for a hint"
	   sleep 1  ;;

esac
echo -e "Enter to continue \c" 
read answer 
done


















