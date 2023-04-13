# SoftGEval - Sitemas de Programación de Rutas
README.md
• Título: Programación de Rutas por Semana.
• Descripción: Servicio REST, que asigna horario de las rutas a los vehiculos, y que conductores deben manejarlos.
• Instalación: Ejecutar script de base datos en SQl Server que contiene las tablas del servicio. 
• Uso: Una vez ejecutado el proyecto deben de crear un usuario con Rol administrador, para obtener el Token que les permitira acceder a los diferentes servicios, que son: Crud de conductores, Vehiculos, Rutas y Horararios, tambien Crud para la creación de usuarios y registro obteniendo Token.

{
  "openapi": "3.0.1",
  "info": {
    "title": "WebApi",
    "version": "1.0"
  },
  "paths": {
    "/api/driver/GetAll": {
      "get": {
        "tags": [
          "Driver"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/driver/GetById/{id}": {
      "get": {
        "tags": [
          "Driver"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/driver/Insert": {
      "post": {
        "tags": [
          "Driver"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Drivers"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Drivers"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Drivers"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/driver/Update": {
      "put": {
        "tags": [
          "Driver"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Drivers"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Drivers"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Drivers"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/driver/delete": {
      "delete": {
        "tags": [
          "Driver"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Drivers"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Drivers"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Drivers"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/auth/login": {
      "post": {
        "tags": [
          "Login"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/VMUser"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/VMUser"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/VMUser"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/route/GetAll": {
      "get": {
        "tags": [
          "Route"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/route/GetById/{id}": {
      "get": {
        "tags": [
          "Route"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/route/Insert": {
      "post": {
        "tags": [
          "Route"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Routes"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Routes"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Routes"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/route/Update": {
      "put": {
        "tags": [
          "Route"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Routes"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Routes"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Routes"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/route/delete": {
      "delete": {
        "tags": [
          "Route"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Routes"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Routes"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Routes"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/schedule/GetAll": {
      "get": {
        "tags": [
          "Schedule"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/schedule/GetById/{id}": {
      "get": {
        "tags": [
          "Schedule"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/schedule/Insert": {
      "post": {
        "tags": [
          "Schedule"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Schedules"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Schedules"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Schedules"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/schedule/Update": {
      "put": {
        "tags": [
          "Schedule"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Schedules"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Schedules"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Schedules"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/schedule/delete": {
      "delete": {
        "tags": [
          "Schedule"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Schedules"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Schedules"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Schedules"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/user/GetAll": {
      "get": {
        "tags": [
          "User"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/user/GetById/{id}": {
      "get": {
        "tags": [
          "User"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/user/Insert": {
      "post": {
        "tags": [
          "User"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Users"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Users"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Users"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/user/Update": {
      "put": {
        "tags": [
          "User"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Users"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Users"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Users"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/user/delete": {
      "delete": {
        "tags": [
          "User"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Users"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Users"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Users"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/vehicle/GetAll": {
      "get": {
        "tags": [
          "Vehicle"
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/vehicle/GetById/{id}": {
      "get": {
        "tags": [
          "Vehicle"
        ],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "integer",
              "format": "int32"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/vehicle/Insert": {
      "post": {
        "tags": [
          "Vehicle"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Vehicles"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Vehicles"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Vehicles"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/vehicle/Update": {
      "put": {
        "tags": [
          "Vehicle"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Vehicles"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Vehicles"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Vehicles"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/api/vehicle/delete": {
      "delete": {
        "tags": [
          "Vehicle"
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/Vehicles"
              }
            },
            "text/json": {
              "schema": {
                "$ref": "#/components/schemas/Vehicles"
              }
            },
            "application/*+json": {
              "schema": {
                "$ref": "#/components/schemas/Vehicles"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "Success"
          }
        }
      }
    },
    "/weatherforecast": {
      "get": {
        "tags": [
          "WebApi"
        ],
        "operationId": "GetWeatherForecast",
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/WeatherForecast"
                  }
                }
              }
            }
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "Drivers": {
        "required": [
          "first_Name",
          "last_Name",
          "ssn"
        ],
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "last_Name": {
            "maxLength": 50,
            "type": "string"
          },
          "first_Name": {
            "maxLength": 50,
            "type": "string"
          },
          "ssn": {
            "maxLength": 20,
            "type": "string"
          },
          "doB": {
            "type": "string",
            "format": "date-time",
            "nullable": true
          },
          "address": {
            "maxLength": 2147483647,
            "type": "string",
            "nullable": true
          },
          "city": {
            "maxLength": 150,
            "type": "string",
            "nullable": true
          },
          "phone": {
            "maxLength": 25,
            "type": "string",
            "nullable": true
          },
          "zip": {
            "maxLength": 10,
            "type": "string",
            "nullable": true
          },
          "active": {
            "type": "boolean"
          }
        },
        "additionalProperties": false
      },
      "Routes": {
        "required": [
          "description"
        ],
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "description": {
            "maxLength": 50,
            "type": "string"
          },
          "driver_Id": {
            "type": "integer",
            "format": "int32"
          },
          "drive": {
            "$ref": "#/components/schemas/Drivers"
          },
          "active": {
            "type": "boolean"
          },
          "vehicle_Id": {
            "type": "integer",
            "format": "int32"
          },
          "vehicle": {
            "$ref": "#/components/schemas/Vehicles"
          }
        },
        "additionalProperties": false
      },
      "Schedules": {
        "required": [
          "start",
          "week_Num"
        ],
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "week_Num": {
            "type": "integer",
            "format": "int32"
          },
          "start": {
            "type": "string",
            "format": "date-time"
          },
          "ends": {
            "type": "string",
            "format": "date-time"
          },
          "active": {
            "type": "boolean"
          },
          "route_Id": {
            "type": "integer",
            "format": "int32"
          },
          "route": {
            "$ref": "#/components/schemas/Routes"
          }
        },
        "additionalProperties": false
      },
      "Users": {
        "required": [
          "names",
          "password",
          "rol",
          "userLogin"
        ],
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "userLogin": {
            "maxLength": 30,
            "minLength": 0,
            "type": "string"
          },
          "names": {
            "maxLength": 30,
            "minLength": 0,
            "type": "string"
          },
          "password": {
            "maxLength": 255,
            "type": "string"
          },
          "rol": {
            "maxLength": 25,
            "minLength": 0,
            "type": "string"
          },
          "active": {
            "type": "boolean"
          }
        },
        "additionalProperties": false
      },
      "Vehicles": {
        "required": [
          "description"
        ],
        "type": "object",
        "properties": {
          "id": {
            "type": "integer",
            "format": "int32"
          },
          "description": {
            "maxLength": 50,
            "minLength": 0,
            "type": "string"
          },
          "year": {
            "type": "integer",
            "format": "int32"
          },
          "make": {
            "type": "integer",
            "format": "int32"
          },
          "capacity": {
            "type": "integer",
            "format": "int32"
          },
          "active": {
            "type": "boolean"
          }
        },
        "additionalProperties": false
      },
      "VMUser": {
        "type": "object",
        "properties": {
          "nomUser": {
            "type": "string",
            "nullable": true
          },
          "password": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "WeatherForecast": {
        "type": "object",
        "properties": {
          "date": {
            "type": "string",
            "format": "date-time"
          },
          "temperatureC": {
            "type": "integer",
            "format": "int32"
          },
          "summary": {
            "type": "string",
            "nullable": true
          },
          "temperatureF": {
            "type": "integer",
            "format": "int32",
            "readOnly": true
          }
        },
        "additionalProperties": false
      }
    }
  }
