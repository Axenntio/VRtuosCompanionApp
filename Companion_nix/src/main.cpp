#include <iostream>
#include <cstdlib>
#include "inc/RtMidi.h"

void midiCallback(double deltatime, std::vector<unsigned char> *message, void *userData)
{
	//message->at(0)
}

int main()
{
	RtMidiIn *midi = new RtMidiIn();
	unsigned int nPorts = midi->getPortCount();

	if (nPorts != 0) {
		std::cout << "There is " << nPorts << " port(s) available!" << std::endl;
		midi->openPort(nPorts - 1);
		midi->setCallback(&midiCallback);
		midi->ignoreTypes(false, false, false);
	}
	else
		std::cout << "No ports available!" << std::endl;
	delete midi;
	return 0;
}
