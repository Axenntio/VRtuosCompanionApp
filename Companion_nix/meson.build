project(
	'VRtuos Companion',
	'cpp',
	version : '0.1',
	default_options : [
		'warning_level=3',
		'cpp_std=c++11'
	]
)

qt5 = import('qt5')
qt5dep = dependency('qt5', modules: ['Core', 'Gui', 'Widgets'])

# Prepare for Linux
asound = dependency('alsa')
pthread = dependency('threads')
defines='-D__LINUX_ALSA__'

# Prepare for macOS
#coremidi = dependency('appleframeworks', modules : 'CoreMIDI')
#coreaudio = dependency('appleframeworks', modules : 'CoreAudio')
#corefoundation = dependency('appleframeworks', modules : 'CoreFoundation')
#defines='-D__MACOSX_CORE__'

executable(
	'VRtuosCompanion',
	[
		qt5.preprocess(
			qresources : 'resources.qrc',
			ui_files: 'ui/ConnectForm.ui',
			moc_headers : 'inc/ConnectForm.hh'
		),
		'src/main.cpp',
		'src/RtMidi.cpp'
	],
	dependencies : [
		qt5dep,
		#coremidi,
		#coreaudio,
		#corefoundation
		asound,
		pthread
	],
	cpp_args : defines
)