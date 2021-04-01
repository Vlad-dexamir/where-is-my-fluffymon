module.exports = {
    preset: 'ts-jest',
    clearMocks: true,
    roots: [
        '<rootDir>/main',
        '<rootDir>/tests',
    ],
    testMatch: [
        '<rootDir>/tests/**/*.test.ts',
        '<rootDir>/tests/**/*.test.tsx',
    ],
    collectCoverageFrom: [
        '<rootDir>/main/**/*.ts',
        '<rootDir>/main/**/*.tsx',
        '!<rootDir>/main/services/**/*.ts',
        '!<rootDir>/main/**/*Container.tsx',
        '!<rootDir>/main/**/*Style.tsx',
        '!<rootDir>/main/**/*Styles.tsx',
        '!<rootDir>/main/**/*StyledVariables.tsx',
        '!<rootDir>/main/**/*StyledVariables.tsx',
        '!<rootDir>/main/store/store.ts',
        '!<rootDir>/main/components/withError.tsx',
        '!<rootDir>/main/components/withRedux.tsx',
    ],
    coverageDirectory: 'coverage',
    setupFilesAfterEnv: ['<rootDir>/tests/setup.ts'],
    snapshotSerializers: ["enzyme-to-json/serializer"],
    globals: {
        'ts-jest': {
            tsConfig: 'tsconfig.test.json',
        },
        'STAGE': 'dev',
    },
    coverageThreshold: {
        "global": {
            "statements": 50,
        },
    },
};