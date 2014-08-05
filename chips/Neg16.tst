load Neg16.hdl,
output-file Neg16.out,
compare-to Neg16.cmp,
output-list in%B1.16.1 nx%D2.1.2 out%B1.16.1;

set in %B0000000000000000,
set nx 0,
eval,
output;

set in %B1111111111111111,
set nx 1,
eval,
output;

set in %B1111111111111111,
set nx 0,
eval,
output;

set in %B0000000000000000,
set nx 1,
eval,
output;

set in %B1001100001110110,
set nx 0,
eval,
output;

set in %B1001100001110110,
set nx 1,
eval,
output;

set in %B1010101010101010,
set nx 0,
eval,
output;

set in %B1010101010101010,
set nx 1,
eval,
output;
