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

out.times.data : timing.exe
    >$@
    for N in $$(seq 100 20 200); do \
        time --format "$$N %e" --output $@ --append \
        mono $< $$N ;\
    done


# Clean compiled files
clean:
	rm -f $(TARGET) *.dll *.exe

