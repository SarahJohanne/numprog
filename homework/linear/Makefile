# Macros
CSC = mcs
CSC_FLAGS = -out:main.exe

# Source files
SRCS = main.cs vector.cs matrix.cs QRGS.cs

# Target
TARGET = main.exe

# Default target
all: $(TARGET)

# Compile the program
$(TARGET): $(SRCS)
	$(CSC) $(CSC_FLAGS) $(SRCS)

# Clean compiled files
clean:
	rm -f $(TARGET) *.dll *.exe

