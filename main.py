import jwt  # Library for JSON Web Tokens (JWT)
import hashlib  # Provides hashing algorithms
import datetime  # Used for working with dates and times
import sqlite3  # SQLite database interface
from cryptography.fernet import Fernet  # Symmetric encryption tool
import os  # Provides functions for interacting with the operating system

# Constants
SECRET_KEY = 'Super_Secret_Key'  # Secret key for encoding and decoding JWT tokens
FERNET_KEY = Fernet.generate_key()  # Generating a key for Fernet encryption
fernet = Fernet(FERNET_KEY)  # Creating a Fernet instance with the generated key
SYSTEM_NAME = 'Windows10'  # Name of the authentication system
DB_NAME = 'auth_system.db'  # Name of the SQLite database file


# Initialize database
def init_db():
    # Connecting to the SQLite database
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    # Drop existing table if it exists
    # cursor.execute("DROP TABLE IF EXISTS users")
    # Creating the users table if it doesn't exist
    cursor.execute('''CREATE TABLE IF NOT EXISTS users (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        username TEXT UNIQUE NOT NULL,
                        password TEXT NOT NULL,
                        salt TEXT NOT NULL,
                        permissions TEXT NOT NULL)''')
    conn.commit()
    conn.close()


# Function to hash a password using SHA-256
def hash_password(password):
    return hashlib.sha256(password.encode()).hexdigest()


# Function to register a new user
def register(username, password, permissions):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    try:
        # Generating a random salt
        salt = os.urandom(16)
        # Converting salt bytes to hex string
        salt_hex = salt.hex()
        # Concatenating the password and salt
        salted_password = salt_hex + password
        # Hashing the salted password
        hashed_password = hashlib.sha256(salted_password.encode()).hexdigest()

        # Inserting user details into the database
        cursor.execute("INSERT INTO users (username, password, salt, permissions) VALUES (?, ?, ?, ?)",
                       (username, hashed_password, salt_hex, permissions))
        conn.commit()
        print(f"User {username} registered successfully.")
    except sqlite3.IntegrityError:
        raise ValueError("Username already exists")
    finally:
        conn.close()


# Function to authenticate a user during login
def login(username, password):
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute("SELECT password, salt FROM users WHERE username = ?", (username,))
    result = cursor.fetchone()
    conn.close()

    if result:
        stored_password = result[0]
        salt = result[1]

        # Concatenating the provided password with the salt
        salted_password = salt + password

        # Hashing the salted password
        hashed_password = hashlib.sha256(salted_password.encode()).hexdigest()

        # Comparing the hashed password with the stored hashed password
        if hashed_password == stored_password:
            # If passwords match, return True to indicate successful login
            return True
    # If no matching user or password mismatch, return False
    return False


# Function to generate a JWT token for a user
def generate_token(username, permissions):
    # Generates the payload
    payload = {
        'username': username,
        'permissions': permissions,
        'system': SYSTEM_NAME,
        'iat': datetime.datetime.utcnow(),  # Issued at time
        'exp': datetime.datetime.utcnow() + datetime.timedelta(hours=1)  # Expiration time
    }
    token = jwt.encode(payload, SECRET_KEY, algorithm='HS256')  # Encoding the payload into a JWT token
    # Encrypting the token using Fernet encryption
    encrypted_token = fernet.encrypt(token.encode())
    return encrypted_token


# Function to validate and decrypt a JWT token
def validate_token(encrypted_token):
    try:
        token = fernet.decrypt(encrypted_token)  # Decrypting the token
        payload = jwt.decode(token, SECRET_KEY, algorithms=['HS256'])  # Decoding the payload from the token
        return payload
    except (jwt.ExpiredSignatureError, jwt.InvalidTokenError, Exception):
        return None


# Main script
if __name__ == "__main__":
    init_db()  # Initializing the database

    user = ""  # Variable to store the current user
    priv = ""  # Variable to store the user's permissions
    logon = "0"  # Variable to control the login state

    while logon == "0":
        # Prompting the user to choose between registration and login
        action = input("Do you want to [register] or [login]?: ").strip().lower()

        if action == 'register':
            while True:
                username = input("Enter username: ").strip()
                password = input("Enter password: ").strip()
                permissions = "0"  # Default permissions for a new user
                try:
                    register(username, password, permissions)  # Calling the register function
                    break
                except ValueError as e:
                    print(e)

        elif action == 'login':
            while True:
                username = input("Enter username: ").strip()
                password = input("Enter password: ").strip()

                try:
                    if login(username, password):  # Calling the login function
                        conn = sqlite3.connect(DB_NAME)
                        cursor = conn.cursor()
                        cursor.execute("SELECT permissions FROM users WHERE username = ?", (username,))
                        permissions = cursor.fetchone()[0]
                        conn.close()

                        token = generate_token(username, permissions)  # Generating a JWT token
                        print("Token generated:", token)

                        validation_result = validate_token(token)  # Validating the token
                        if validation_result:
                            print("Token is valid:", validation_result)
                            user = validation_result['username']
                            if validation_result['permissions'] == '1':
                                priv = "Admin"
                            else:
                                priv = "Regular"
                            logon = '1'
                            print(user)
                            print(priv)
                            print(logon)
                        else:
                            print("Token is invalid or expired")
                    else:
                        print("Login failed. Please try again.")
                except ValueError as e:
                    print(e)

                while logon == '1':
                    if logon == '1':
                        print("===MAIN USER AREA===")
                        selection = input("Do you want the [Admin Area] or [User Area]?").strip().lower()
                        if selection == "admin area":
                            # Check if the user has admin permissions
                            if priv == 'Admin':
                                # User has admin permissions, allow access to admin area
                                print("=== ADMIN AREA ===")
                                while logon == '1':
                                    selection = input("Go [Back] or [Log Out]?").strip().lower()
                                    if selection == "back":
                                        print("Going back...")
                                        break
                                    elif selection == "log out":
                                        logon = '0'
                                        break
                                    else:
                                        print("Invalid action. Please choose either 'Back' or 'Log Out'.")
                            else:
                                # User does not have admin permissions, deny access
                                print("You do not have permission to access the admin area.")
                        elif selection == "user area":
                            # Check if the user has user permissions
                            if priv == 'Regular' or priv == 'Admin':
                                # User has user permissions, allow access to user area
                                print("=== USER AREA ===")
                                while logon == '1':
                                    selection = input("Go [Back] or [Log Out]?").strip().lower()
                                    if selection == "back":
                                        print("Going back...")
                                        break
                                    elif selection == "log out":
                                        logon = "0"
                                        break
                                    else:
                                        print("Invalid action. Please choose either 'Back' or 'Log Out'.")
                            else:
                                # User does not have user permissions, deny access
                                print("You do not have permission to access the user area.")
                        else:
                            print("Invalid action. Please choose either 'Admin Area' or 'User area'.")
        else:
            print("Invalid action. Please choose either 'register' or 'login'.")
