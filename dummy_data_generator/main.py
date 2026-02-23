from schemas.schemas import *

if __name__ == '__main__':
    for name, schema in schemas.items():
        print('*' * 20, name.capitalize(), '*' * 20)
        for attribute in schema:
            print(attribute)
