# Macros
CSC = mcs
CSC_FLAGS = -out:main.exe
CSC_TIMING_FLAGS = -out:timing.exe
# Source files
SRCS = main.cs vector.cs matrix.cs QRGS.cs
TIMING_SRC = timing.cs vector.cs matrix.cs QRGS.cs

# Target
TARGET = main.exe
TIMING_TARGET = timing.exe
all: $(TARGET) $(TIMING_TARGET)

# Compile the programs
$(TARGET): $(SRCS)
	$(CSC) $(CSC_FLAGS) $(SRCS)

$(TIMING_TARGET): $(TIMING_SRC)
	$(CSC) $(CSC_TIMING_FLAGS) $(TIMING_SRC)

default: Out.txt Outtimes.txt Makefile

Outtimes.txt : timing.exe Makefile
	>$@
	for N in $$(seq 100 20 200); do \
		time --format "$$N %e" --output $@ --append \
		mono $< $$N ;\
		done
Out.txt : main.exe
	mono $< > $@

# Clean compiled files
clean:
	rm -f $(TARGET) $(TIMING_TARGET) *.dll *.exe [Oo]ut*

