project('VRtuos Companion', 'cpp',
		version : '0.1',
		default_options : ['warning_level=3', 'cpp_std=c++11'])


#asound = dependency('asound')
#pthread = dependency('thread')
#-D__LINUX_ALSA__
coremidi = dependency('appleframeworks', modules : 'CoreMIDI')
coreaudio = dependency('appleframeworks', modules : 'CoreAudio')
corefoundation = dependency('appleframeworks', modules : 'CoreFoundation')

executable('VRtuosCompanion',
	['src/main.cpp', 'src/RtMidi.cpp'],
	dependencies : [coremidi, coreaudio, corefoundation],
	cpp_args : '-D__MACOSX_CORE__'
)