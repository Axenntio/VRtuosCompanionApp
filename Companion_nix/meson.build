project('VRtuos Companion', 'cpp',
		version : '0.1',
		default_options : ['warning_level=3', 'cpp_std=c++11'])


# Prepare for Linux
#asound = dependency('asound')
#pthread = dependency('thread')
#defines='-D__LINUX_ALSA__'

# Prepare for macOS
coremidi = dependency('appleframeworks', modules : 'CoreMIDI')
coreaudio = dependency('appleframeworks', modules : 'CoreAudio')
corefoundation = dependency('appleframeworks', modules : 'CoreFoundation')
defines='-D__MACOSX_CORE__'

executable('VRtuosCompanion',
	['src/main.cpp', 'src/RtMidi.cpp'],
	dependencies : [coremidi, coreaudio, corefoundation],
	cpp_args : defines
)