from schemas.base.datatype import *

class Attribute:
    def __init__(self, **kwargs):
        self.__name: str = kwargs.get('name', 'number')
        self.__datatype: DataType = kwargs.get('datatype', DataType())

    @property
    def name(self) -> str:
        return self.__name

    @property
    def datatype(self):
        return self.__datatype

    def __repr__(self) -> str:
        return f"{self.name} : {self.datatype}"
