from enum import Enum

class Type(Enum):
    # Regular Types
    NONE = 0,           # Null type
    INT = 1,            # Regular integer values
    FLOAT = 2,          # Floating point values
    STRING = 3,         # String values
    BOOLEAN = 4,        # Boolean values
    LIST = 5,           # List of any further type

    # Special Types
    CUSTOM_OBJECT = 6   # A custom object type
    EMAIL = 7           # Email of the user
    PASSWORD = 8        # Password of the user
    USER_NAME = 9            # Name of the user

class Mode(Enum):
    RANDOM = 0,     # Random mode for generating random values
    CUSTOM = 1      # Custom mode for generating custom values from given list

class DataType:
    def __init__(self, **kwargs):
        self.__type: Type = kwargs.get('type', Type.INT)
        self.__list_type: Type | None = kwargs.get('list_type', None) if self.__type is Type.LIST else None
        self.__mode: Mode = kwargs.get('mode', Mode.RANDOM) if self.__type is not Type.NONE else Mode.CUSTOM

    @property
    def type(self) -> Type:
        return self.__type

    @property
    def mode(self) -> Mode:
        return self.__mode

    @property
    def list_type(self) -> Type | None:
        return self.__list_type

    def __repr__(self) -> str:
        return f"'{self.type.name}' - '{self.mode.name}'" if self.__list_type is None else f"'{self.type.name}' - '{self.list_type.name}' - '{self.mode.name}'"
