// Runs an infinite loop that listens to the keyboard input. 
// When a key is pressed (any key), the program blackens the screen,
// i.e. writes "black" in every pixel. When no key is pressed, the
// program clears the screen, i.e. writes "white" in every pixel.

// detect keyboard input
(START)
@KBD
D=M

// store a value, 'colour' repesenting 16 black or white pixels as appropriate
@colour
M=0
@UPDATE
D;JEQ
@colour
M=!M

// write black into every pixel when keyboard != zero
(UPDATE)
@i
M=0
(LOOP)
@i
D=M
@8192 // the number of RAM locations in the screen memory map
D=D-A
@START // program loops forever
D;JGE

@i
D=M
@SCREEN
D=D+A // work out current location
@location
M=D
@colour
D=M
@location
A=M  // switch to current location and put the correct colour in it
M=D

@i
M=M+1
@LOOP
0;JMP
