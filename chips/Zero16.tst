load Zero16.hdl,
output-file Zero16.out,
compare-to Zero16.cmp,
output-list in%B1.16.1 zx%D2.1.2 out%B1.16.1;

set in %B0000000000000000,
set zx 0,
eval,
output;

set in %B1111111111111111,
set zx 1,
eval,
output;

set in %B1111111111111111,
set zx 0,
eval,
output;

set in %B0000000000000000,
set zx 1,
eval,
output;

set in %B1001100001110110,
set zx 0,
eval,
output;

set in %B1001100001110110,
set zx 1,
eval,
output;

set in %B1010101010101010,
set zx 0,
eval,
output;

set in %B1010101010101010,
set zx 1,
eval,
output;
