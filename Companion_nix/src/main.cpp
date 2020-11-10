#include <iostream>
#include <QtWidgets/QApplication>
#include "inc/RtMidi.h"
#include "inc/ConnectForm.hh"

void midiCallback(double deltatime, std::vector<unsigned char> *message, void *userData)
{
	//message->at(0)
}

int main(int argc, char **argv)
{
	QApplication app(argc, argv);
	ConnectForm connectForm;
	RtMidiIn *midi = new RtMidiIn();
	unsigned int portNumber = midi->getPortCount();

	for (unsigned char i = 0; i < portNumber; i++) {
		connectForm.addKeyboard(std::to_string(i));
	}
	//midi->openPort(nPorts - 1);
	//midi->setCallback(&midiCallback);
	//midi->ignoreTypes(false, false, false);

	connectForm.show();
	app.exec();
	delete midi;
	return 0;
}
